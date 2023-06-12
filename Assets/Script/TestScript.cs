using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // public Button leftButton;
    // public Button rightButton;

    // private bool isMovingLeft;
    // private bool isMovingRight;

    // private float moveSpeed = 1000f;

    public void Awake()
    {
    }

    private void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        // }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }
}
