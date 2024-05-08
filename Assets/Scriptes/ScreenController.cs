using System;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private event Action OnPointerUpButton;
    private event Action<float> OnPointerDownButton;
    private int sizeWidthScreen = Screen.width;
    private void OnEnable()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        OnPointerUpButton = playerController.HandlerButtonUp;
        OnPointerDownButton = playerController.HandlerButtonDown;
    }
    private void Update()
    {
       if(Input.touchCount != 0)
       {
            CheckingPressingScreen();
       } 
    }
    private void CheckingPressingScreen()
    {
        Touch touch = Input.GetTouch(Input.touchCount - 1);
        if(touch.phase == TouchPhase.Began | touch.phase == TouchPhase.Stationary | touch.phase == TouchPhase.Moved)
        {
            // Debug.Log(touch.position.x + "<" + sizeWidthScreen / 2 + "," + (touch.position.x < sizeWidthScreen / 2));
            if(touch.position.x < sizeWidthScreen / 2)
            {
                OnPointerDownButton?.Invoke(-1);
                Debug.Log("Нажали на левую сторону");
            }
            else
            {
                OnPointerDownButton?.Invoke(1);
                Debug.Log("Нажали на правую сторону");
            }
        }
        else
        {
            Debug.Log("Отпустили");
            OnPointerUpButton.Invoke();
        }
    }
}
