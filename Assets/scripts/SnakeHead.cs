using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHead : MonoBehaviour
{
    public float moveSpeed = 1f; //set move speed
    private Vector2 moveDirection = Vector2.right; //snake will always start by moving right
    private float moveTimer; //initialize move timer
    public float moveInterval = 0.2f; //set moveInterval
    public GameObject snakeBodyPrefab; //create snakebodyprefab
    private List<Transform> body = new List<Transform>(); // we will use a list to store our snake body segments

    public ScoreCounter scoreCounter; // used to keep track of score
    

    public DeathAudio deathAudio; //reference death audio
    public EatingAudio eatingAudio;//reference eating audio
    public AudioSource backGroundMusic;//reference BGM

    private bool isPaused = false;
    void Start()
    {
        //resume time
        Time.timeScale = 1f;
        //find scoreCounter
        scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.score = 0;

        //play BGM
        backGroundMusic.Play();
    
    }
    void Update()
    {
        
        //used to increase speed to make the game harder as the score increases
        if (scoreCounter.score >= 1000)
    {
         
        moveInterval = 0.1f; 
    } else if(scoreCounter.score >= 500){
        moveInterval = 0.15f;
    }

        //This is to toggle music
         if (Input.GetKeyDown(KeyCode.M)) 
        {
            ToggleMusic();
        }
        

        //handles pausing during game
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause(); // Call method togglepause
        }

        if (isPaused) return; // If the game is paused, get out of update 

        //movement logic
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveDirection != Vector2.down)
    {
        moveDirection = Vector2.up;
        
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow) && moveDirection != Vector2.up)
    {
        moveDirection = Vector2.down;
        
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow) && moveDirection != Vector2.right)
    {
        moveDirection = Vector2.left;
       
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow) && moveDirection != Vector2.left)
    {
        moveDirection = Vector2.right;
        
    }

       

        moveTimer -= Time.deltaTime; // count down timer

        
    if (moveTimer <= 0)
    {
        //store current head position (this is for the body position)
        Vector3 previousPosition = transform.position;

        // move snake head
        transform.Translate(moveDirection * moveSpeed);

        
        
        //update the move timer
        moveTimer = moveInterval; 

        // Move the body segments
        for (int i = 0; i < body.Count; i++)
        {
            Vector3 tempPosition = body[i].position; // store current body position
            body[i].position = previousPosition; //move the body to where the head was
            previousPosition = tempPosition; // update previous position for the body
        }
    }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Barrier") || other.CompareTag("SnakeBody"))
    {
        // Game over 
        deathAudio.PlaySound();
        
        //set timescale to 0 to allow deathaudio to execute without snake running out of frame
        Time.timeScale = 0f;
        OnGameOver();
        // use to delay the scene load so death audio can execute beforehand
        StartCoroutine(LoadSceneAfterDelay("GameOver"));

    }
    if(other.CompareTag("Apple")){
       
            //play eating audio
            eatingAudio.PlaySound();
            
            FindObjectOfType<AppleSpawner>().SpawnApple(); // spawn new apple
            Destroy(other.gameObject); // remove eaten apple
            GrowSnake(); //Grow snake
            scoreCounter.score += 100; // increase score

            //try to set high score
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score);
            
    }
}
//used to create snake bodies
private void GrowSnake()
{
    // Instantiate new body segment
    GameObject newBody = Instantiate(snakeBodyPrefab);
    
    // Check if there are existing body segments, needed to add this to avoid adding the body inside the head causing the snake to die 
    if (body.Count > 0)
    {
        // If there are body segments, spawn the new one at the position of the last segment
        newBody.transform.position = body[body.Count - 1].position;
    }
    else
    {
        // If this is the first segment, spawn it behind the head based on the current move direction
        newBody.transform.position = transform.position - (Vector3)moveDirection;
    }

    // Add the new body segment to the list
    body.Add(newBody.transform);
}
//used to delay the load scene so my death sound effect can play
private IEnumerator LoadSceneAfterDelay(string sceneName)
{
    yield return new WaitForSecondsRealtime(deathAudio.GetClipLength() + 0.6f);
    Time.timeScale = 1f;
    SceneManager.LoadScene(sceneName);
}
//pause game
private void TogglePause()
{
        isPaused = !isPaused; 
        Time.timeScale = isPaused ? 0f : 1f; 



}
//turn music on and off
private void ToggleMusic()
    {
        if (backGroundMusic.isPlaying)
        {
            backGroundMusic.Pause(); //pause music if  playing
        }
        else
        {
            backGroundMusic.UnPause(); //resume music if paused
        }
    }

//save highscore and score 
private void OnGameOver()
{
    //get both scores 
    int finalScore = scoreCounter.getScore();
    int highScore = HighScore.getScore();
    //set both scores
    PlayerPrefs.SetInt("HighScore", highScore);
    PlayerPrefs.SetInt("FinalScore", finalScore); 

    PlayerPrefs.Save(); // save both prefs
    
}

}
