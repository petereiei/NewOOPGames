using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score;

    Text TextScore;

    private void Awake()
    {
        TextScore = GetComponent<Text>();

        score = 0;
    }

    private void Update()
    {
        TextScore.text = "Score: " + score;
    }
}
