using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //  public float moveSpeed = 5f;

    // private bool isMoving;
    // private bool isMovingRight;
    // private Rigidbody2D rb;

    // private void Awake()
    // {
    //     // rb = GetComponent<Rigidbody2D>();
    //     // rb.isKinematic = true; // Set Rigidbody2D to kinematic
    // }
    // private void Update()
    // {
    //     // 檢查是否有觸摸螢幕
    //     if (Input.touchCount > 0)
    //     {
    //         Debug.Log("Touching");
    //         // Touch touch = Input.GetTouch(0);
    //         Vector3 touchPosition = Input.mousePosition;

    //         // 檢查觸摸位置是否在螢幕的右半邊
    //         if (touchPosition.x > Screen.width / 2f)
    //         {
    //             isMovingRight = true;
    //         }
    //         else
    //         {
    //             isMovingRight = false;
    //         }

    //         isMoving = true;
    //     }
    //     else
    //     {
    //         isMoving = false;
    //     }
    // }

    // private void FixedUpdate()
    // {
    //     // 根據輸入來移動物件
    //     if (isMoving)
    //     {
    //         Debug.Log("Moving");
    //         if (isMovingRight)
    //         {
    //             rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    //         }
    //         else
    //         {
    //             rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    //         }
    //     }
        
    // }



    private int playerID = 0;

    private float moveForce = 100f;
    private float maxSpeed = 100f;

    // [SerializeField] private float playerControl_acre = 3f; // touchPosition.y < Screen.height / playerControl_arec
    [SerializeField] private GameObject playerAcre;
    private Rigidbody2D rb;
    private bool isMoving;
    private bool isMovingRight;
    
    private float playerAcre_W;
    private float playerAcre_H;
    // [SerializeField] private FloatingJoystick floatingJoystick;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // rb.isKinematic = true; // Set Rigidbody2D to kinematic

        RectTransform playerAcre_RT = playerAcre.GetComponent<RectTransform>();
        // playerAcre_W = playerAcre_RT.rect.width;
        playerAcre_H = playerAcre_RT.rect.height;
    }
    private void Update() {
        // Check if there is touch input
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            // Debug.Log("Touching");
            Vector3 touchPosition = Input.mousePosition;

            // 檢查觸摸位置是否在螢幕的右半邊
            if (touchPosition.x > Screen.width / 2f && touchPosition.y < playerAcre_H)
            {
                isMoving = true;
                isMovingRight = true;
            }
            // 檢查觸摸位置是否在螢幕的左半邊
            else if (touchPosition.x < Screen.width / 2f && touchPosition.y < playerAcre_H)
            {
                isMoving = true;
                isMovingRight = false;
            }
            else
            {
                isMoving = false;
                isMovingRight = false;
            }
        }
        else
        {
            // Debug.Log("Not Touching");
            isMoving = false;
            isMovingRight = false;
        }
    }

    private void FixedUpdate()
    {
         // Move the player based on the input
        if (isMoving)
        {
            if (isMovingRight)
            {
                rb.velocity = new Vector2(moveForce, rb.velocity.y);
            }else
            {
                rb.velocity = new Vector2(-moveForce, rb.velocity.y);
            }
        }
        else
        {
            // rb.velocity = new Vector2(-moveForce, rb.velocity.y);
            rb.velocity = Vector2.zero; // 停止移動，將速度設為零
        }

        // Limit the maximum speed
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
