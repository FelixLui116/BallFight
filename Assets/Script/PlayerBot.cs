using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ball;
    
    private float moveSpeed = 200f;

    [SerializeField]private bool movement_ = true; 
    [SerializeField]private bool is_updown = false; 
    [SerializeField]private bool shouldMove = true; 
    private Vector3 target_Position;
    private Rigidbody2D rb;
    public float stoppingDistance = 1f;

    //SetBall
    public void SetBall(GameObject ball)
    {
        this.ball = ball;
    }
    //SetBall
    public void SetUpDown(bool is_updown_)
    {
        is_updown = is_updown_;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       StartCoroutine(UpdateBotMovement());
    }
    
    private IEnumerator UpdateBotMovement()
    {
        while (true)
        {
            // Randon number between 0.25 to 1
            // float randomDelay = Random.Range(0.25f, 1f);
            float randomDelay =2f;

            target_Position = ball.transform.position;
            shouldMove = true;
            yield return new WaitForSeconds(randomDelay); // Wait for 0.75 second before updating again
            shouldMove = false;
            rb.velocity = Vector2.zero; // Stop the bot's movement after the delay
    
        }
    }
    private void FixedUpdate() {
    if (target_Position != null && shouldMove)
    {
        Vector2 direction;

        if (is_updown)
        {
            // Move up and down along the y-axis
            direction = new Vector2(0f, target_Position.y - transform.position.y).normalized;
            rb.velocity = new Vector2(0f, direction.y * moveSpeed);

            // Freeze X position
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            // Move left and right along the x-axis
            direction = new Vector2(target_Position.x - transform.position.x, 0f).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, 0f); // Freeze Y position

            // Check if the bot's velocity is close to zero
            if (rb.velocity.magnitude < 0.1f)
            {
                // Apply a high angular velocity to achieve fast rotation
                rb.angularVelocity = Mathf.Sign(rb.angularVelocity) * 200f; // Set a positive or negative value based on the current angular velocity
            }
            else
            {
                // Reset the angular velocity to zero
                rb.angularVelocity = 0f;
            }
        }
    }
    else
    {
        // If the bot should not move, set its velocity and angular velocity to zero
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    
        // /////////////////////////////   OLD CODE   /////////////////////////////
        //     // If the bot should not move, return without updating the velocity
        // if (!shouldMove)
        // {
        //     return;
        // }

        // // Otherwise, determine the movement direction and set the velocity accordingly
        // Vector2 direction;

        // if (is_updown)
        // {
        //     // Move up and down along the y-axis
        //     direction = new Vector2(0f, target_Position.y - transform.position.y).normalized;
        //     rb.velocity = new Vector2(0f, direction.y * moveSpeed);

        //     // Freeze X position
        //     rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        // }
        // else
        // {
        //     // Move left and right along the x-axis
        //     direction = new Vector2(target_Position.x - transform.position.x, 0f).normalized;
        //     rb.velocity = new Vector2(direction.x * moveSpeed, 0f); // Freeze Y position

        //     rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        // }
        // /////////////////////////////   OLD CODE   /////////////////////////////


        // if (target_Position != null && shouldMove)
        // {
        //     Vector2 direction;

        //     if (is_updown)
        //     {
        //         // Move up and down along the y-axis
        //         direction = new Vector2(0f, target_Position.y - transform.position.y).normalized;
        //         rb.velocity = new Vector2(0f, direction.y * moveSpeed);
                
        //         // Freeze X position
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //     }
        //     else
        //     {
        //         // Move left and right along the x-axis
        //         direction = new Vector2(target_Position.x - transform.position.x, 0f).normalized;
        //         rb.velocity = new Vector2(direction.x * moveSpeed, 0f); // Freeze Y position
                
        //         rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        
        //     }
        // }else
        // {
        //     // If the bot should not move, set its velocity to zero
        //     rb.velocity = Vector2.zero;
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Corner"))
        {
            movement_ = false;
            // Resume movement after a delay of 1 second
            StartCoroutine(ResumeMovementAfterDelay(0.5f));
        }
    }

    private IEnumerator ResumeMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        movement_ = true; // Resume the movement
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
