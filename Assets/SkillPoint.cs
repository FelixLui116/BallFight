using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoint : MonoBehaviour
{
    public enum SkillType  // Fire, Water, Wind, Thunder
    {
        None,
        Fire,
        Water,
        Wind,
        Thunder
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
            if (id > -1 &&  playerInfo.GetSkillCount() <1 ) // -1 not hit player yet
            {  
                ApplySkillToPlayer(playerInfo);
                DestroySkillPoint();
            }       
        }
    }
    // pass number of skill to player info
    // Fire Skill: Deals extra damage or ignites the target.
    // Water skills: Reduce the target's movement speed or freeze the target.
    // Wind Skill: Push away the target or cause a range of effects.
    // Thunder Skill: Causes electric shock damage or paralyzes the target.
    private void ApplySkillToPlayer(PlayerInfo player) 
    {
        switch (skillType)
        {
            case SkillType.Fire:
                player.SetSkill(PlayerInfo.SkillType.Fire);
                break;
            case SkillType.Water:
                player.SetSkill(PlayerInfo.SkillType.Water);
                break;
            case SkillType.Wind:;
                player.SetSkill(PlayerInfo.SkillType.Wind);
                break;
            case SkillType.Thunder:;
                player.SetSkill(PlayerInfo.SkillType.Thunder);
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
