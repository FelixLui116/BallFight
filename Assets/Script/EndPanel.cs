using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public Button restartButton;

    public Text scoreText;
    public Text playerIDText;
    public Color playerColor;
    public GameObject playerEndInfo_Obj;
    public GameObject playerGroup;


    private int score = 0;
    private int playerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndGameInfo(PlayerInfo [] playerInfo){
        //  Debug.Log("=== " +playerInfo.Length); // 4 
        for (int i = 0; i < playerInfo.Length ; i++)
        {
            if (playerInfo[i] != null)
            {
                Debug.Log("=== " +playerInfo[i].GetScore() );
                // clone playerEndInfo_Obj
                GameObject playerEndInfo = Instantiate(playerEndInfo_Obj, transform.position, Quaternion.identity, playerGroup.transform);
                //GetPlayerColor
                playerEndInfo.transform.GetChild(0).GetComponent<Image>().color = playerInfo[i].GetPlayerColor();           
                // GetPlayerID
                playerEndInfo.transform.GetChild(1).GetComponent<Text>().text = "P" + playerInfo[i].GetPlayerID().ToString();
                // GetScore
                playerEndInfo.transform.GetChild(2).GetComponent<Text>().text = "" + playerInfo[i].GetScore().ToString();
                
            }
            
        }
    }
}
