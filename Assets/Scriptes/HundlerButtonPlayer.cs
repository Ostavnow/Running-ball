using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HundlerButtonPlayer : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    private PlayerController playerController;
    private event Action OnPointerUpButton;
    private event Action<float> OnPointerDownButton;
    private enum directionButton
    {LeftButton = -1, RightButton = 1}
    [SerializeField]
    private directionButton selectDirectionButton;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        OnPointerDownButton += playerController.HandlerButtonDown;
        OnPointerUpButton += playerController.HandlerButtonUp;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnPointerDownButton?.Invoke((float)selectDirectionButton);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        OnPointerUpButton?.Invoke();
    }
}
