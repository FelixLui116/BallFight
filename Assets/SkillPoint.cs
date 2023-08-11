using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoint : MonoBehaviour
{
    public enum SkillType
    {
        Skill1,
        Skill2,
        Skill3
    }
    public SkillType skillType;

    private PlayerInfo player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {   
            Ball ball = other.GetComponent<Ball>();
            int id = ball.GetPlayerID();
            PlayerInfo playerInfo = ball.GetPlayerInfo();
            Debug.Log($"playerInfo: {playerInfo}");
            if (id > -1) // -1 not hit player yet
            {  
                ApplySkillToPlayer(playerInfo);
                DestroySkillPoint();
            }       
        }
    }
    // pass number of skill to player info
    private void ApplySkillToPlayer(PlayerInfo player) 
    {
        switch (skillType)
        {
            case SkillType.Skill1:
                player.SetSkill(1);
                break;
            case SkillType.Skill2:
                player.SetSkill(2);
                break;
            case SkillType.Skill3:;
                player.SetSkill(3);
                break;
        }
    }

    private void DestroySkillPoint()
    {
        Destroy(gameObject);
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
