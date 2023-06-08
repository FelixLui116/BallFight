using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float gameTime = 60f; // 1 minute in seconds
    private bool isGameOver;
    [SerializeField] private int playerCount = 2;
    [SerializeField] private float timer;
    public Text timerText;

    [Header("PLAYER")]
    [SerializeField] private GameObject playerStartPosotion;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerAll;
    [SerializeField] private GameObject playerControlArea;
    [SerializeField] private Color[] playerColor = new Color[] {Color.red, Color.blue, Color.green, Color.yellow};
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


            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);// 更新UI文本
            // timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            timerText.text = string.Format("{0:D2}", seconds);
    


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
            // Renderer renderer = player.GetComponent<Renderer>();
            // renderer.material.color = playerColor[i];
            Image image = player.GetComponent<Image>();
            image.color = playerColor[i];

            PlayerInfo pif = player.GetComponent<PlayerInfo>();
            // 得到颜色
            pif.SetPlayerColor(playerColor[i]);
            pif.SetPlayerID(i);


            // UI info
            GameObject _playerUI = Instantiate(socreAreaPrefab, new Vector3(0,0,0), Quaternion.identity , playerinfoGroup.transform);
            PlayerInfo_UI playerUI = _playerUI.GetComponent<PlayerInfo_UI>();

            pif.SetPlayerInfo_UI(playerUI);


            GameObject sa_obj = socreAreaGroup.transform.GetChild(i).gameObject;
            ScoreArea sa = sa_obj.GetComponent<ScoreArea>();
            sa.SetPlayerInfo(pif);


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
