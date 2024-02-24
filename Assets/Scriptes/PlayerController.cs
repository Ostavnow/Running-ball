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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"),0,0);
        rb.AddForce(moveInput * movePower,ForceMode.Impulse);
        rb.AddForce(PushingForce * PushingPower,ForceMode.Force);
    }
}
