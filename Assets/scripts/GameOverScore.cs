using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    //used to show score in the game over screen
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // Retrieve the saved score
        scoreText.text = "Final Score: " + finalScore.ToString();
    }
}
