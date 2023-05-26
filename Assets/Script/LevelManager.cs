using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float gameTime = 60f; // 1 minute in seconds
     [SerializeField] private float timer;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameTime;
        isGameOver = false;
        
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Update the timer
            timer -= Time.deltaTime;

            // Check if the time has run out
            if (timer <= 0f)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game End!");
        // ResetTimer();
        
        // Perform any game over actions here
    }

    public void ResetTimer()
    {
        timer = gameTime;
        isGameOver = false;
    }
}
