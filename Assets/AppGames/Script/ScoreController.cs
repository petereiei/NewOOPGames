using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ScoreController : MonoBehaviour
    {
        private PlayerProgress playerProgress;


        void Start()
        {
            LoadPlayerProgress();
        }

        public void SubmitNewPlayerScore(int newScore)
        {
            if (newScore > playerProgress.highestScore)
            {
                playerProgress.highestScore = newScore;
                SavePlayerProgress();
            }
        }

        private void LoadPlayerProgress()
        {
            playerProgress = new PlayerProgress();

            if (PlayerPrefs.HasKey("highestScore"))
            {
                playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
            }
        }

        private void SavePlayerProgress()
        {          
            PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
        }
    }



