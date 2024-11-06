using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonAssignments : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    
    
    //Assigning buttons to functions
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
        
    }
    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
        
    }
    
    //showcase highscore on game over screen and start screen
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); 
        highScoreText.text = "High Score: " + highScore.ToString(); 
    }
   
}
