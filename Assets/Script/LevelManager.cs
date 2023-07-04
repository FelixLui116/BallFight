using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float gameTime = 60f; // 1 minute in seconds
    private bool isGameOver = true;
    [SerializeField] private int playerCount = 2;
    [SerializeField] private float timer;
    public Text timerText;
    public GameObject canvas;
    public GameObject gameEndPanel;

    private EndPanel endPanel;

    [SerializeField] private PlayerInfo[] playerInfo = new PlayerInfo[4];

    [Header("PLAYER")]
    [SerializeField] private GameObject playerStartPosotion;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject playerAll;
    [SerializeField] private GameObject playerControlArea;
    [SerializeField] private GameObject buttonLeft;
    [SerializeField] private GameObject buttonRight;
    [SerializeField] private Color[] playerColor = new Color[] {Color.red, Color.blue, Color.green, Color.yellow};
    // Start is called before the first frame update

    
    [Header("Socre")]
    [SerializeField] private GameObject socreAreaPrefab;
    [SerializeField] private GameObject playerinfoGroup;
    [SerializeField] private GameObject socreAreaGroup;

    
    [Header("Ball")]
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private GameObject BallResetPsotion;
    [SerializeField] private GameObject ball;

    private void Awake() {
        
        endPanel = gameEndPanel.GetComponent<EndPanel>();
        endPanel.restartButton.onClick.AddListener(StartGame);
    }

    void Start()
    {
        
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
            if (timer <= 0.05f)
            {
                EndGame();
            }

        }
    }

    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game End!");
        PopGameEndPanel();
        Ball_Stop();
        Playerinfo_destroy();
        PlayerOject_destroy();
        // ResetTimer();
        // Perform any game over actions here
    }

    public void ResetTimer()
    {
        timer = gameTime;
        isGameOver = false;
    }

    private void Ball_Stop(){
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        // destroy ball
        Destroy(ball);
        ball = null;
    }
    private void Playerinfo_destroy(){
        for (int i = 0; i < playerinfoGroup.transform.childCount; i++)
        {
            Destroy(playerinfoGroup.transform.GetChild(i).gameObject);
        }
    }
    private void PlayerOject_destroy(){
        for (int i = 0; i < playerAll.transform.childCount; i++)
        {
            Destroy(playerAll.transform.GetChild(i).gameObject);
        }
    }


    public void StartGame(){
        
        gameEndPanel.SetActive(false);
        timer = gameTime;
        isGameOver = false;
        
        ResetTimer();
        CloneBall();
        ClonePlayer();
        // Debug.Log("=== " +playerInfo.Length);
    }

    private void PopGameEndPanel(){
        // GameObject gameEndPanel = Instantiate(gameEndPanelPrefab,   canvas.transform);
        gameEndPanel.SetActive(true);
        
        endPanel.ShowEndGameInfo(playerInfo);
        // EndPanel endPanel = gameEndPanel.GetComponent<EndPanel>();
        // endPanel.restartButton.onClick.AddListener(StartGame);

        // gameEndPanel.name = "GameEndPanel";
        // GameEndPanel gep = gameEndPanel.GetComponent<GameEndPanel>();
        // gep.SetPlayerInfo(playerInfo);
    }

    private void ClonePlayer(){
        for (int i = 0; i < playerCount; i++)
        {
            GameObject psp = playerStartPosotion.transform.GetChild(i).gameObject;
            Vector3 spawnPosition = psp.transform.position; // 從玩家起始位置物件獲取生成位置

            GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity , playerAll.transform);
            player.name = "Player_" + i.ToString();

            // Debug.Log("is Player");
            PlayerControl pc = player.GetComponent<PlayerControl>();
            if (i == 0 ){  // is player
                // pc.ControllArea =playerControlArea;
                // pc.SetisAI(false);
                // pc.SetControllArea();
                pc.leftButton = buttonLeft.GetComponent<PlayerButtonPress>();
                pc.rightButton = buttonRight.GetComponent<PlayerButtonPress>();
            }else{  // is AI
                // pc.SetisAI(true);
                pc.enabled = false;
                PlayerBot playerBot= player.GetComponent<PlayerBot>();
                playerBot.enabled = true;
                playerBot.SetBall(ball);
            }

            // Renderer renderer = player.GetComponent<Renderer>();
            // renderer.material.color = playerColor[i];
            Image image = player.GetComponent<Image>();
            image.color = playerColor[i];

            // PlayerInfo pif = player.GetComponent<PlayerInfo>();
            playerInfo[i] = player.GetComponent<PlayerInfo>();
            // Debug.Log("is PlayerInfo: " + playerInfo[i].name );

            // 得到颜色
            // pif.SetPlayerColor(playerColor[i]);
            // pif.SetPlayerID(i);
            playerInfo[i].SetPlayerColor(playerColor[i]);
            playerInfo[i].SetPlayerID(i);

            // UI info
            GameObject _playerUI = Instantiate(socreAreaPrefab, new Vector3(0,0,0), Quaternion.identity , playerinfoGroup.transform);
            PlayerInfo_UI playerUI = _playerUI.GetComponent<PlayerInfo_UI>();

            // pif.SetPlayerInfo_UI(playerUI);
            playerInfo[i].SetPlayerInfo_UI(playerUI);

            playerUI.SetColor( image.color );

            GameObject sa_obj = socreAreaGroup.transform.GetChild(i).gameObject;
            sa_obj.SetActive(true);
            ScoreArea sa = sa_obj.GetComponent<ScoreArea>();
            // sa.SetPlayerInfo(pif);
            sa.SetPlayerInfo(playerInfo[i]);
        }
    }

    private void CloneBall(){
        GameObject _ball = Instantiate(BallPrefab, BallResetPsotion.transform.position, Quaternion.identity , playerAll.transform);
        _ball.name = "Ball_Clone";
        _ball.GetComponent<Ball>().GettingBallResetPosition(BallResetPsotion);
        ball = _ball;
    }


}
