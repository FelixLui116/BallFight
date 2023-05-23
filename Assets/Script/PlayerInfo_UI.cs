using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo_UI : MonoBehaviour
{
    [SerializeField] private GameObject playerinfo;
    [SerializeField] private Text score;
    
    private PlayerInfo playerInfo;

    private void Awake() {
        playerInfo = playerinfo.GetComponent<PlayerInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(int newScore){
        newScore = playerInfo.GetScore();
        score.text = newScore.ToString();
    }

}
