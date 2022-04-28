using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class PlayerController : MonoBehaviour
    {
        private NavMeshAgent agent;
        private ThirdPersonCharacter character;

        [SerializeField] private List<GameObject> collectables;

        private Transform target;
        private int targetIndex = 0;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;

            SetTarget();
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                agent.destination = target.position;
                if(agent.remainingDistance > agent.stoppingDistance)
                {
                    character.Move(agent.desiredVelocity, false, false);
                    return;
                }
            }
            
                character.Move(Vector3.zero, false, false);
         
        }

        void SetTarget()
        {
            if (collectables.Count > 0)
            {
                targetIndex = Random.Range(0, collectables.Count);
                target = collectables[targetIndex].transform;
                return;
            }
            target = null;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Collectable"))
            {
                collectables.RemoveAt(targetIndex);   
                Destroy(collision.gameObject);
                SetTarget();
            }
        }
    }
}