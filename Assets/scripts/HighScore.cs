using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //Class is pretty much a copy paste from my applepicker game, except for the addition of getscore.
    static private TextMeshProUGUI _UI_TEXT; 
    static public int SCOREE = 1000;

    private TextMeshProUGUI txtCom;

    void Awake () 
    {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore")) {

             SCORE = PlayerPrefs.GetInt("HighScore");
        }
       
         PlayerPrefs.SetInt("HighScore", SCORE);
    }
    static public int SCORE {

         get { return SCOREE; }

         private set {

             SCOREE = value;

             PlayerPrefs.SetInt("HighScore", value); 

             if ( _UI_TEXT != null ) {

                 _UI_TEXT.text = "High Score: " +
                value.ToString( "#,0" );
            }
        }
    }
    [Tooltip( "Check this box to reset the HighScore in PlayerPrefs" )]

    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {

         if ( resetHighScoreNow ) {
             resetHighScoreNow = false;
             PlayerPrefs.SetInt( "HighScore", 1000 );
             Debug.LogWarning( "PlayerPrefs HighScore reset to 1,000." );
         }
    }

    static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {

         if ( scoreToTry <= SCORE ) return; // If scoreToTry is too low, return
        SCORE = scoreToTry;
    }

    //needed to find score and save it to player pref in snakehead class
    static public int getScore(){
        return SCORE;
    }

   
}
