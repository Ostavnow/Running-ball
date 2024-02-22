using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x,player.position.y + offset.y,player.position.z + offset.z);
    }
}
