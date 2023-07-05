using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button settingsButton;

    [SerializeField] private string [] SceneName;
    
    // gameobject setting panel
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject startPanel;
    
    [Header("Start Panel")]
    public Button StartPanel_Back;
    public Button [] StartGameBtn_playerCount;
    public int[] playerCount = {2,4};


    // Start is called before the first frame update
    void Start()
    {
        // startButton.onClick.AddListener(()=>
        // {
        //     ToScene(SceneName[0]);
        //     // ToScene("Game1Scene");
        // });
        
        settingsButton.onClick.AddListener(() => {
            settingPanel.SetActive(true);
            startPanel.SetActive(false);
        });

        startButton.onClick.AddListener(() => {
            settingPanel.SetActive(false);
            startPanel.SetActive(true);
        });

        for (int i = 0; i < StartGameBtn_playerCount.Length; i++)
        {
            int count = playerCount[i];
            StartGameBtn_playerCount[i].onClick.AddListener(() => {
                ToScene(SceneName[0]);
                EnterPlayerCount(count);
            });
        }

        // quitButton.onClick.AddListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void EnterPlayerCount (int _int){
        GlobalManager.Instance.SetGameMode(_int);
        // Debug.Log("Game mode: " + GlobalManager.Instance.GameMode(_int) );
    }
    private void PlayerCount_btn(){

    }

}
