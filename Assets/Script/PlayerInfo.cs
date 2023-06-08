using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int score = 0;
    [SerializeField] private PlayerInfo_UI playerInfo_UI;
    private int skill = 0;

    private int _playerID = 0;

    private Color _color;
    
    // public int Life = 3;
    // public int Level = 1;


    //Getting Score
    public int GetScore(){
        return score;
    }

    //Setting Score
    public void SetScore(int newScore){
        score += newScore;
    }

    //Getting Skill
    public int GetSkill(){
        return skill;
    }
    //Setting Skill
    public void SetSkill(int newSkill){
        skill = newSkill;
    }

    public int GetPlayerID()   
    {
        return _playerID;
    } 
    public void SetPlayerID(int value)    
    {
        _playerID = value;
    }

    public void SetPlayerColor(Color _Color){
        _color = _Color;
    }
    public Color GetPlayerColor(){
        return _color;
    }
    // setter PlayerInfo_UI
    public void SetPlayerInfo_UI(PlayerInfo_UI playerInfo_UI){
        this.playerInfo_UI = playerInfo_UI;
    }
    // getter PlayerInfo_UI
    public PlayerInfo_UI GetPlayerInfo_UI(){
        return playerInfo_UI;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
