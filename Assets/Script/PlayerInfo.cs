using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private int skill = 0;

    private int playerID = 0;
    
    // public int Life = 3;
    // public int Level = 1;

    //Getting Score
    public int GetScore(){
        return score;
    }

    //Setting Score
    public void SetScore(int newScore){
        score = newScore;
    }

    //Getting Skill
    public int GetSkill(){
        return skill;
    }
    //Setting Skill
    public void SetSkill(int newSkill){
        skill = newSkill;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
