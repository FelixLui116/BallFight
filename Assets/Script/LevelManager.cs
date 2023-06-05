using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float gameTime = 60f; // 1 minute in seconds
    private bool isGameOver;
    [SerializeField] private int playerCount = 2;
    [SerializeField] private float timer;

    [Header("PLAYER")]
    [SerializeField] private GameObject playerStartPosotion;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerAll;
    [SerializeField] private GameObject playerControlArea;
    // Start is called before the first frame update

    
    [Header("Socre")]
    [SerializeField] private GameObject socreAreaPrefab;
    [SerializeField] private GameObject playerinfoGroup;
    [SerializeField] private GameObject socreAreaGroup;


    void Start()
    {
        timer = gameTime;
        isGameOver = false;
        
        StartGame();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            // Update the timer
            timer -= Time.deltaTime;

            // Check if the time has run out
            if (timer <= 0f)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game End!");
        // ResetTimer();
        
        // Perform any game over actions here
    }

    public void ResetTimer()
    {
        timer = gameTime;
        isGameOver = false;
    }

    public void StartGame(){
        
        ClonePlayer();
    }

    private void ClonePlayer(){
        for (int i = 0; i < playerCount; i++)
        {
            GameObject psp = playerStartPosotion.transform.GetChild(i).gameObject;
            Vector3 spawnPosition = psp.transform.position; // 從玩家起始位置物件獲取生成位置

            GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity , playerAll.transform);
            player.name = "Player_" + i.ToString();
            PlayerInfo pif = player.GetComponent<PlayerInfo>();
            pif.SetPlayerID(i);


            // UI info
            GameObject scoreArea = Instantiate(socreAreaPrefab, new Vector3(0,0,0), Quaternion.identity , playerinfoGroup.transform);
            PlayerInfo_UI playerUI = scoreArea.GetComponent<PlayerInfo_UI>();
            playerUI.SetPlayerInfo(pif);


            GameObject sa_obj = socreAreaGroup.transform.GetChild(i).gameObject;
            ScoreArea sa = sa_obj.GetComponent<ScoreArea>();
            sa.SetPlayerInfo(playerUI);


            if (i == 0 ){  // is player
                Debug.Log("is Player");
                PlayerControl pc = player.GetComponent<PlayerControl>();
                pc.ControllArea =playerControlArea;
                pc.SetisAI(false);
                pc.SetControllArea();
            }else{  // is AI
            }
        }
    }


}
