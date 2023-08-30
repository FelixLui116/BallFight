using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillPoint : MonoBehaviour
{
    public enum SkillType  // Fire, Water, Wind, Thunder
    {
        Fire,
        Water,
        Wind,
        Thunder
    }
    public SkillType skillType;

    private PlayerInfo player;
    private Animation animation;
    public Image skillImage;

    private void Awake() {
        animation = GetComponent<Animation>();
        skillImage = GetComponent<Image>(); 

    }
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

    private void ChangeSkillBallColor()
    {
        Color fireColor = Color.red;
        Color waterColor = Color.blue;
        Color windColor = Color.green;
        Color thunderColor = Color.yellow;
        // Set the color based on the skill type
        switch (skillType)
        {
            case SkillType.Fire:
                skillImage.color = fireColor;
                break;
            case SkillType.Water:
                skillImage.color = waterColor;
                break;
            case SkillType.Wind:
                skillImage.color = windColor;
                break;
            case SkillType.Thunder:
                skillImage.color = thunderColor;
                break;
            // Add more cases as needed
            default:
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
        // GetComponent<Animation>().Play("SkillColorChange");

        skillType = (SkillType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(SkillType)).Length);
    
        // Change the color based on the skill type
        ChangeSkillBallColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
