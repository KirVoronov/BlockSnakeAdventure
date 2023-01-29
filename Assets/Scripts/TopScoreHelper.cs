using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockSnake
{
    public class TopScoreHelper : MonoBehaviour
    {
        public static string FilePath = "LastTopScore.txt";
        public static bool CanUpdateScore = false;

        public static List<LastScore> AllScores = new List<LastScore>();

        [SerializeField] private TMP_Text _TopScore;

        private void Start()
        {
            UpdateScores();
        }

        private void Update()
        {
            if (CanUpdateScore)
            {
                UpdateScores();
                CanUpdateScore = false;
            }
        }

        public void OnStart()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0, LoadSceneMode.Single);
            Time.timeScale = 1.0f;
            return;
        }

        public void OnQuit()
        {
            if (Application.isEditor)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                Application.Quit();
            }
        }

        private void UpdateScores()
        {
            if (File.Exists(FilePath))
            {
                AllScores.Clear();
                string allRecordsString = File.ReadAllText(FilePath);
                AllScores = JsonConvert.DeserializeObject<List<LastScore>>(allRecordsString);
            }

            StringBuilder sb = new StringBuilder();
            if (AllScores != null)
            {
                foreach (var score in AllScores.OrderBy(s => s.LastTopScore).Take(6))
                {
                    sb.Append(score.LastTopScore.ToString()).AppendLine();
                }
            }
            else
            {
                AllScores = new List<LastScore>();
            }

            _TopScore.text = sb.ToString();
        }

        [Serializable]
        public class LastScore
        {
            public int LastTopScore;

            public LastScore()
            {

            }

            public LastScore(int lastTopScore)
            {
                LastTopScore = lastTopScore;
            }
        }
    }
}