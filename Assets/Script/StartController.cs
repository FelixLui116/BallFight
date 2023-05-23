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
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(()=>
        {
            ToScene(SceneName[0]);
            // ToScene("Game1Scene");
        });
        settingsButton.onClick.AddListener(() => {
            settingPanel.SetActive(true);
            // startPanel.SetActive(false);
        });
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

}
