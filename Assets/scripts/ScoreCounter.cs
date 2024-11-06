using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    //copy paste of applepicker scorecounter, except for addition of getscore

     [Header("Dynamic")]
// b
 public int score = 0;

 private TextMeshProUGUI uiText; 
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Score: " + score.ToString( "#,0" ); 
    }
    void resetScore(){
        score = 0;
    }
    //used in snakehead to save to playerpref
    public int getScore(){
        return score;
    }
}

