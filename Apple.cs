using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab; 
    public int gridWidth = 20; 
    public int gridHeight = 20; 
    public float tileSize = 1f; 

    void Start()
    {
        SpawnApple(); //spawn an apple at the start
    }

    public void SpawnApple()
    {
        // generate random coordinates for the apple to spawn inside the grid
        int randomX = Random.Range(0, gridWidth);
        int randomY = Random.Range(0, gridHeight);

        // Calculate world position based on grid coordinates
        Vector3 spawnPosition = new Vector3(randomX * tileSize, randomY * tileSize, 0f);

        // create the apple at the calculated position
        Instantiate(applePrefab, spawnPosition, default);
    }
}
