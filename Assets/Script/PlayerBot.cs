using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ball;
    
    private float moveSpeed = 100f;

    [SerializeField]private bool movement_ = true; 
    [SerializeField]private bool is_updown = false; 
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
            target_Position = ball.transform.position;
            yield return new WaitForSeconds(0.75f); // Wait for 0.75 second before updating again
        }
    }
    private void FixedUpdate() {
        
        if (target_Position != null)
        {
            Vector2 direction = (target_Position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, target_Position);

            if (distance > stoppingDistance)
            {
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Corner"))
        {
            movement_ = false;
            // Resume movement after a delay of 1 second
            StartCoroutine(ResumeMovementAfterDelay(0.75f));
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
