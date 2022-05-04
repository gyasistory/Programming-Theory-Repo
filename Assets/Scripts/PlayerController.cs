using System;
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

        [HideInInspector]
        public Transform target;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;

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

        public void SetTarget(Transform transform)
        {
           target = transform;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Collectable"))
            {
               Collectable collectable = collision.gameObject.GetComponent<Collectable>();
                if (collectable != null)
                {
                    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
                    if (CompareTag("Cowboy"))
                    {
                        gameManager.UpdateCowboyScore(collectable.points);
                    } else if (CompareTag("Lady"))
                    {
                        gameManager.UpdateLadyScore(collectable.points);
                    }
                    gameManager.DeleteCollectable(collision.gameObject.GetInstanceID());
                }
            }
        }
    }
}