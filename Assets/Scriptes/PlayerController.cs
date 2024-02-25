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
    [SerializeField] private float PushingPower = 1f;
    [SerializeField] private Vector3 PushingForce = new Vector3(0,-1,1);
    public event Action GameOver;
    public event Action Finish;
    public event Action TookMoney;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * movePower,ForceMode.Impulse);
        rb.velocity = PushingForce * PushingPower;
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
            GameOver.Invoke();
        }
        else if(other.CompareTag("Finish"))
        {
            Finish?.Invoke();
        }
        else if(other.CompareTag("Money"))
        {
            TookMoney?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
