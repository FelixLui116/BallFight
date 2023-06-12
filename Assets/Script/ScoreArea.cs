using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    // public int scoreBall = 1;
    // public int ScoreID;
    public PlayerInfo playerInfo;

    private void Awake() {
        // playerInfo_UI = GameObject.Find("PlayerInfo").GetComponent<PlayerInfo_UI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Debug.Log("Score!");
            // Increment the score or perform any other scoring logic
            // 
            Ball ball = collision.GetComponent<Ball>();

            // Debug.Log("ball.GetscoreBall(): "+ ball.GetscoreBall());
            playerInfo.SetScore(ball.GetscoreBall());   // update player info Score

            playerInfo.GetPlayerInfo_UI().ScoreUpdate(playerInfo.GetScore());     // update player UI Score by using playerinfo score
    


            // reset the ball's position and ball score
            ball.ResetPosition();
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
    // Setter ScoreArea
    public void SetPlayerInfo(PlayerInfo _playerInfo){
        this.playerInfo = _playerInfo;
    }
}
