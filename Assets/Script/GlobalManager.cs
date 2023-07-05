using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sfxMusic;

    public static GlobalManager Instance {get; private set;}
    public MusicController musicController;

    private int [] playerIDs = new int[4] {1, 2, 3, 4};
    private Color [] playerColors = new Color[4] {Color.red, Color.blue, Color.green, Color.yellow};

    private int gameMode = 0; // 0: 2 player, 1: 4 player

    private void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            
            DontDestroyOnLoad(backgroundMusic);
            DontDestroyOnLoad(sfxMusic);
            Instance = this;
        }
        //  else {
            // Destroy(gameObject);
            // return;
        // }

        // musicController = new MusicController(backgroundMusic, sfxMusic);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Load Scene Async
    public void LoadSceneAsync(string sceneName) {
        Debug.Log("Loading Scene: " + sceneName);
        SceneManager.LoadSceneAsync(sceneName , LoadSceneMode.Single); 
        // SceneManager.LoadSceneAsync(sceneName); 
    }
    public void SetGameMode(int _int){  // setter / getter
        gameMode = _int;
    }

    public int GetGameMode(){
        return gameMode;
    }


}
