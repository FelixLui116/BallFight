using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private float hitForce_base = 100f;
    [SerializeField] private float hitForce_add = 10f;
    // [SerializeField] private float hitForce_total = 0f;


    private Rigidbody2D rb;
    public PhysicsMaterial2D ballPhysicsMaterial;
    private int playerID = -1;
    private Image ball_color;
    private Animation animation;

    [SerializeField] private int scoreBall = 1;
    private int hitAddScore_count = 1;

    public Text score_text;

    [SerializeField] private GameObject ballResetPostion;
    private PlayerInfo playerInfo;

    // private Vector3 ballreset_position = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update

    public void GettingBallResetPosition(GameObject _ballResetPostion){
        ballResetPostion = _ballResetPostion;
    }

    private void Awake() {
        
        ball_color = GetComponent<Image>();
        animation = GetComponent<Animation>();

        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = ballPhysicsMaterial;

        // ballResetPostion = GameObject.Find("BallResetPos");
    }

    public void SetScoreBall(int value){
        // Debug.Log("SetScore: "+ value.ToString());
        scoreBall = value;
        score_text.text = scoreBall.ToString();
        // return scoreBall;
    }
    
    public int GetscoreBall(){
        return scoreBall;
    }

    void Start()
    {
        StartCoroutine(StartDelay());
        
    }

    IEnumerator StartDelay()
    {
        GetComponent<Animation>().Play("BallColorChange");

        yield return new WaitForSeconds(1f);

        // Generate a random direction
        // X , Y range  up and down
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.value > 0.5f ? 1f : -1f;
        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        score_text.text = scoreBall.ToString();

        // Apply the initial force to the ball
        rb.AddForce(randomDirection * hitForce_base, ForceMode2D.Impulse); 
    }


    
    private void FixedUpdate()
    {
        // Move the ball based on input
        DrawForceArrow();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Ball hit player!!!");
            playerInfo = collision.gameObject.GetComponent<PlayerInfo>();
            SetBallColor(playerInfo.GetPlayerID(), playerInfo.GetPlayerColor() );
            HitAddScore(hitAddScore_count); // adding score count.
            
            // Apply additional force to the ball
            // hitForce_total += hitForce_add; 
            // float currentForce = hitForce_base + hitForce_total;
            // Debug.Log("currentForce: "+ currentForce.ToString() + " || hitForce_total: "+hitForce_total);
            // Debug.Log("hitForce_total: "+hitForce_total + " || hitForce_…base: "+hitForce_base + " || hitForce_add: "+hitForce_add );
            Vector2 forceDirection = collision.GetContact(0).normal;
            // rb.AddForce(forceDirection * currentForce, ForceMode2D.Impulse);
            rb.AddForce(forceDirection * hitForce_add, ForceMode2D.Impulse);

            // Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // Vector2 contactPoint = collision.GetContact(0).point;

            // // Calculate the normalized direction from the paddle to the contact point
            // Vector2 paddleToContact = (contactPoint - (Vector2)collision.transform.position).normalized;

            // // Calculate the horizontal force direction based on the paddle-to-contact direction
            // float horizontalForceDirection = Mathf.Sign(paddleToContact.x);

            // rb.AddForce(new Vector2( 0f, 0f), ForceMode2D.Impulse);

            // // Apply the horizontal force to the ball
            // rb.AddForce(new Vector2(horizontalForceDirection * hitForce_base, 0f), ForceMode2D.Impulse);

        }
    }

    public void SetBallColor(int _playerID, Color _color){
        // ball_color = GetComponent<Renderer>();
        // ball_color.material.SetColor("_Color", _Color);
        ball_color.color = _color;
        this.playerID = _playerID;
    }

    public void HitAddScore(int hit_count){
        // if(hit_count> ){
        // }
        int newScore = scoreBall + hitAddScore_count; 
        SetScoreBall(newScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition(){
        this.transform.position = ballResetPostion.transform.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        
        hitAddScore_count = 1;

        playerID = -1;

        SetScoreBall(1);
        // 
        // playerInfo.SetScore(1);

        Start();
    }

    public int GetBall_ID(){
        return this.playerID;
    }

    private void DrawForceArrow()
    {
        Vector2 forceDirection = rb.velocity.normalized;
        float forceMagnitude = rb.velocity.magnitude;

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(forceDirection.x, forceDirection.y, 0f) * forceMagnitude * 0.5f;

        Debug.DrawRay(startPos, endPos - startPos, Color.red);
    }
}
