using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

    int score;
    public Text TextScores;

    private void Start()
    {
        score = PlayerPrefs.GetInt("highestScore");
        TextScores.text = score.ToString();
    }

    public void loadscene()
    {
        Application.LoadLevel("GamePlay");
    }


}
