using Assets.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {


        [SerializeField] List<Transform> collectableSpawnPoints;

        [SerializeField] List<GameObject> collectablePrefabs = new List<GameObject>();

        [SerializeField] PlayerController CowboyPlayer;
        [SerializeField] PlayerController LadyPlayer;

        private List<GameObject> activeCollectables = new List<GameObject>();

        private bool isGameActive = false;
        private bool isGameOver = false;

        private float startGameTimer = 3;

        // Start is called before the first frame update
        void Start()
        {
            LoadCollectables();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameActive && !isGameOver)
            {
                startGameTimer -= Time.deltaTime;

                if (startGameTimer <= 0)
                {
                    isGameActive = true;
                }
            }
            if (isGameActive && activeCollectables.Count > 0)
            {
                if (CowboyPlayer.target == null)
                {
                    int randomCollectable = Random.Range(0, activeCollectables.Count);
                    CowboyPlayer.SetTarget(activeCollectables[randomCollectable].transform);
                }
                if (LadyPlayer.target == null)
                {
                    int randomCollectable = Random.Range(0, activeCollectables.Count);
                    LadyPlayer.SetTarget(activeCollectables[randomCollectable].transform);
                }
            }
        }

        void LoadCollectables()
        {
            int count = DataManager.Instance.NumberOfCollectables;
            for (int i = 0; i < count; i++)
            {
                int randomCollectable = Random.Range(0, collectablePrefabs.Count);
                int randomSpawnPoint = Random.Range(0, collectableSpawnPoints.Count);

                GameObject collectable = collectablePrefabs[randomCollectable];
                Transform spawnPoint = collectableSpawnPoints[randomSpawnPoint];

                collectable.transform.position = spawnPoint.position;
                activeCollectables.Add(Instantiate(collectable));

                // Remove Spawn point to prevent duplicate spawn positions
                collectableSpawnPoints.RemoveAt(randomSpawnPoint);
            }
        }

        internal void UpdateLadyScore(int points)
        {
            DataManager.Instance.LadyScore += points;
        }

        internal void DeleteCollectable(int collectableID)
        {
            GameObject collect = activeCollectables.Find(x => x.GetInstanceID() == collectableID);
            activeCollectables.Remove(collect);
            Destroy(collect);
        }

        internal void UpdateCowboyScore(int points)
        {
            DataManager.Instance.CowboyScore += points;
        }
    }
}
