using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Vector3 moveInput;
    private Rigidbody rb;
    [SerializeField] private float movePower = 1f;
    [SerializeField] private float pushingPower = 1f;
    [SerializeField] private Vector3 PushingForce = new Vector3(0,-1,1);
    private bool controllable = true;
    public event Action GameOver;
    public event Action Finish;
    public event Action TookMoney;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(controllable)
        {
            rb.AddForce(moveInput * movePower,ForceMode.Impulse);
            rb.velocity = PushingForce * pushingPower;
        }
    }
    public void HandlerButtonDown(float direction)
    {
        moveInput = new Vector3(direction,0,0);
    }
    public void HandlerButtonUp()
    {
        moveInput = new Vector3(0,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Obstacles>())
        {
            GameOver?.Invoke();
            other.GetComponent<Obstacles>().PlayGameOverAnimation();
            controllable = false;
        }
        else if(other.CompareTag("Finish"))
        {
            Finish?.Invoke();
            controllable = false;
        }
        else if(other.CompareTag("Money"))
        {
            TookMoney?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
