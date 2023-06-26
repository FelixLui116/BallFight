using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo_UI : MonoBehaviour
{
    // [SerializeField] private GameObject playerinfo;
    [SerializeField] private Text score;
    [SerializeField] private Image playerColor;
    //[SerializeField] private Color color;
    

    private void Awake() {
        // playerInfo = GameObject.Find("Player_1").GetComponent<PlayerInfo>();
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
        score.text = newScore.ToString();
    }
    public void SetColor(Color _color){
        playerColor.color = _color;
    }


    // // Setter PlayerInfo
    // public void SetPlayerInfo(PlayerInfo playerInfo){
    //     this.playerInfo = playerInfo;
    // }
}
