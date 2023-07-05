using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    // public int scoreBall = 1;
    // public int ScoreID;
    public PlayerInfo[] playerInfo;

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

            if(ball.GetBall_ID() == -1){ // No one hit the ball (while ball)
                ball.ResetPosition();
                return;
            } 

            PlayerInfo _pif = playerInfo[ball.GetBall_ID()];

            // Debug.Log("ball.GetscoreBall(): "+ ball.GetscoreBall());
            _pif.SetScore(ball.GetscoreBall());   // update player info Score
            _pif.GetPlayerInfo_UI().ScoreUpdate(_pif.GetScore());     // update player UI Score by using playerinfo score
    


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
    public void SetPlayerInfo(PlayerInfo[] _playerInfo){
        this.playerInfo = _playerInfo;
    }
}
