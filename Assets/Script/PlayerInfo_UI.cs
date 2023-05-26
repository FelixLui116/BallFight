using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo_UI : MonoBehaviour
{
    // [SerializeField] private GameObject playerinfo;
    [SerializeField] private Text score;
    
    private PlayerInfo playerInfo;

    private void Awake() {
        playerInfo = GameObject.Find("Player_1").GetComponent<PlayerInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(int newScore){

        playerScore_Add(newScore);

        newScore = playerInfo.GetScore();
        score.text = newScore.ToString();
    }

    public void playerScore_Add(int newScore)
    {
        playerInfo.SetScore(newScore);
    }

}
