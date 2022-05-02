using System.Collections;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;

        public string PlayerName;
        public int NumberOfCollectables;
        public int CowboyScore;
        public int LadyScore;

        public ScoreData localScoreData;

        private readonly string fileName = "/score.json";

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       

        [System.Serializable]
        public class ScoreData
        {
            public string PlayerName;
            public int NumberOfCollectables;
            public int CowboyScore;
            public int LadyScore;
        }

        public ScoreData GetScoreData()
        {
            return localScoreData;
        }

        public void SaveScoreData()
        {
            ScoreData data = new ScoreData();
            data.PlayerName = PlayerName;
            data.NumberOfCollectables = NumberOfCollectables;
            data.CowboyScore = CowboyScore;
            data.LadyScore = LadyScore;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + fileName, json);
            LoadScoreData();
        }

        public void LoadScoreData(bool updateLocale = true)
        {
            string path = Application.persistentDataPath + fileName;
            if (!File.Exists(path))
            {
                string json = File.ReadAllText(path);
                localScoreData = JsonUtility.FromJson<ScoreData>(json);
                if (updateLocale)
                {
                    PlayerName = localScoreData.PlayerName;
                    NumberOfCollectables = localScoreData.NumberOfCollectables;
                    CowboyScore = localScoreData.CowboyScore;
                    LadyScore = localScoreData.LadyScore;
                }
            }
        }
    }
}