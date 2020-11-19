using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int highScore;
    Text score;

    // Start is called before the first frame update
    void Start()
    {

        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.scoreValue > highScore)
        {
            highScore = ScoreScript.scoreValue;
        }
        score.text = "high score: " + highScore;
    }
}
