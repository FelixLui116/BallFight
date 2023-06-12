using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour //, IPointerDownHandler, IPointerUpHandler
{
    public PlayerButtonPress leftButton;
    public PlayerButtonPress rightButton;

    // public bool isMovingLeft = false;
    // public bool isMovingRight = false;

    private Rigidbody2D rb;
    private float moveForce = 100f;
    private float maxSpeed = 100f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // leftButtonTrigger

        // leftButton.onClick.AddListener(OnLeftButtonDown);
        // leftButton.onRelease.AddListener(OnLeftButtonUp);
        // rightButton.onClick.AddListener(OnRightButtonDown);
        // rightButton.onRelease.AddListener(OnRightButtonUp);


        // 綁定按鈕的按下和放開事件
        // EventTrigger leftButtonTrigger = leftButton.gameObject.GetComponent<EventTrigger>();
        // EventTrigger rightButtonTrigger = rightButton.gameObject.GetComponent<EventTrigger>();
        // // 監聽按下事件
        // EventTrigger.Entry leftPointerDownEntry = new EventTrigger.Entry();
        // leftPointerDownEntry.eventID = EventTriggerType.PointerDown;
        // leftPointerDownEntry.callback.AddListener((eventData) => { OnLeftButtonDown(); });
        // leftButtonTrigger.triggers.Add(leftPointerDownEntry);

    }

    private void FixedUpdate()
    {
        
        // Debug.Log("isMovingRight: " + rightButton.buttonPressed  + "  ||  isMovingLeft: " + leftButton.buttonPressed);
        if (leftButton.buttonPressed)
        {
            rb.velocity = new Vector2(-moveForce, rb.velocity.y);
        }
        else if (rightButton.buttonPressed)
        {
            rb.velocity = new Vector2(moveForce, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // // Limit the maximum speed
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }


    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerDown");
    //     if (eventData.pointerPress == leftButton.gameObject)
    //     {
    //         isMovingLeft = true;
    //     }
    //     else if (eventData.pointerPress == rightButton.gameObject)
    //     {
    //         isMovingRight = true;
    //     }
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerUp");
    //     if (eventData.pointerPress == leftButton.gameObject)
    //     {
    //         isMovingLeft = false;
    //     }
    //     else if (eventData.pointerPress == rightButton.gameObject)
    //     {
    //         isMovingRight = false;
    //     // }
    //     // 停止物件移動
    //     StopMoving();
    // }

    // private void StopMoving()
    // {
    //     // 停止物件的移動
    //     isMovingLeft = false;
    //     isMovingRight = false;
    // }

    //////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////
    // private float moveForce = 100f;
    // private float maxSpeed = 100f;

    // // [SerializeField] private float playerControl_acre = 3f; // touchPosition.y < Screen.height / playerControl_arec
    // public GameObject ControllArea;
    // private Rigidbody2D rb;
    // private bool isMoving;
    // private bool isMovingRight;
    
    // private float ControllArea_W;
    // private float ControllArea_H;

    // private bool _isAI;

    // public Button skillButton;
    // // [SerializeField] private FloatingJoystick floatingJoystick;
    
    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody2D>();
        
    //     // skillButton.onClick.AddListener(UseSkill);
    // }
    // private void Update() {
    //     // Check if there is touch input
    //     if (Input.touchCount > 0 || Input.GetMouseButton(0))
    //     {
    //         // Debug.Log("Touching");
    //         Vector3 touchPosition = Input.mousePosition;

    //         // 檢查觸摸位置是否在螢幕的右半邊
    //         if (touchPosition.x > Screen.width / 2f && touchPosition.y < ControllArea_H)
    //         {
    //             isMoving = true;
    //             isMovingRight = true;
    //         }
    //         // 檢查觸摸位置是否在螢幕的左半邊
    //         else if (touchPosition.x < Screen.width / 2f && touchPosition.y < ControllArea_H)
    //         {
    //             isMoving = true;
    //             isMovingRight = false;
    //         }
    //         else
    //         {
    //             isMoving = false;
    //             isMovingRight = false;
    //         }
    //     }
    //     else
    //     {
    //         // Debug.Log("Not Touching");
    //         isMoving = false;
    //         isMovingRight = false;
    //     }
    // }

    // private void FixedUpdate()
    // {
    //      // Move the player based on the input
    //     if (isMoving)
    //     {
    //         if (isMovingRight)
    //         {
    //             rb.velocity = new Vector2(moveForce, rb.velocity.y);
    //         }else
    //         {
    //             rb.velocity = new Vector2(-moveForce, rb.velocity.y);
    //         }
    //     }
    //     else
    //     {
    //         // rb.velocity = new Vector2(-moveForce, rb.velocity.y);
    //         rb.velocity = Vector2.zero; // 停止移動，將速度設為零
    //     }

    //     // Limit the maximum speed
    //     rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    // }


    // public bool GetisAI(){
    //     return _isAI;
    // }
    // public void SetisAI(bool value){
    //     _isAI = value;
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    // public void SetControllArea(){
    //     // rb.isKinematic = true; // Set Rigidbody2D to kinematic
    //     if (ControllArea != null)
    //     {
    //         RectTransform ControllArea_RT = ControllArea.GetComponent<RectTransform>();
    //         // ControllArea_W = ControllArea_RT.rect.width;
    //         ControllArea_H = ControllArea_RT.rect.height;
    //     }
    // }

    // public void UseSkill(){
    //     Debug.Log("UseSkill");
    // }

    
}
