using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float hitForce = 150f;

    private Rigidbody2D rb;
    public PhysicsMaterial2D ballPhysicsMaterial;
    private int playerID;

    private int scoreValue = 1;

    [SerializeField] private GameObject ballResetPostion;

    // private Vector3 ballreset_position = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update

    private void Awake() {
        
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = ballPhysicsMaterial;

        ballResetPostion = GameObject.Find("BallResetPos");
    }

    public void SetScore(int value){
        scoreValue = value;
        // return scoreValue;
    }
    
    public int GetScoreValue(){
        return scoreValue;
    }

    void Start()
    {
        // Generate a random direction
        // X , Y range  up and down
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.value > 0.5f ? 1f : -1f;
        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        // Apply the initial force to the ball
        rb.AddForce(randomDirection * hitForce, ForceMode2D.Impulse);
    
    }
    private void FixedUpdate()
    {
        // Move the ball based on input
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 contactPoint = collision.GetContact(0).point;

            // Calculate the normalized direction from the paddle to the contact point
            Vector2 paddleToContact = (contactPoint - (Vector2)collision.transform.position).normalized;

            // Calculate the horizontal force direction based on the paddle-to-contact direction
            float horizontalForceDirection = Mathf.Sign(paddleToContact.x);

            rb.AddForce(new Vector2( 0f, 0f), ForceMode2D.Impulse);

            // Apply the horizontal force to the ball
            rb.AddForce(new Vector2(horizontalForceDirection * hitForce, 0f), ForceMode2D.Impulse);

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition(){
        this.transform.position = ballResetPostion.transform.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Start();
    }
}
