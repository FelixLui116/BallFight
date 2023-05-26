using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    // public int scoreValue = 1;

    [SerializeField] private PlayerInfo_UI playerInfo_UI;

    private void Awake() {
        // playerInfo_UI = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo_UI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Debug.Log("Score!");
            // Increment the score or perform any other scoring logic
            
            // Reset the ball position or perform any other necessary actions
            Ball ball = collision.GetComponent<Ball>();
            ball.ResetPosition();
            
            playerInfo_UI.ScoreUpdate(ball.GetScoreValue());
            // float ballScore = ball.GetScoreValue();

            // playerInfo_UI.ScoreUpdate(ballScore);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
