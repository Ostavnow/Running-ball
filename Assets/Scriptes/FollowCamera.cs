using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;
    private Transform cameraTransform;
    [SerializeField] private float speed = 20f;
    private Vector3 velocity = Vector3.forward;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        cameraTransform = transform;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x + offset.x,player.position.y + offset.y,player.position.z + offset.z);
        transform.position = Vector3.Slerp(cameraTransform.position,targetPosition,speed * Time.fixedDeltaTime);
    }
}
