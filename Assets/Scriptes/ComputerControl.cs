using System;
using UnityEngine;

public class ComputerControl : MonoBehaviour
{
    private event Action OnPointerUpButton;
    private event Action<float> OnPointerDownButton;
    void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        OnPointerUpButton = playerController.HandlerButtonUp;
        OnPointerDownButton = playerController.HandlerButtonDown;
    }
    void Update()
    {
        
    }
    private void SetDirection()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        if(0 > inputHorizontal)
        {
            OnPointerDownButton?.Invoke(-1);
        }
        else if(0 < inputHorizontal)
        {
            OnPointerDownButton?.Invoke(1);
        }
        else
        {
            OnPointerUpButton?.Invoke();
        }
    }
}
