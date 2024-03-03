using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator animation;
    private Transform playerTransform;
    [SerializeField]
    private AnimationClip animationClip;
    [SerializeField]
    private AnimationCurve animationCurve;
    private AudioManager audioManager;
    private Transform cameraTransform;
    private void Start()
    {
        animation = GetComponent<Animator>();
        playerTransform = FindObjectOfType<PlayerController>().transform;
        audioManager = FindObjectOfType<AudioManager>();
        cameraTransform = Camera.main.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            StartCoroutine(Animation());
            audioManager.Play("Spring");
        }
    }
    private IEnumerator Animation()
    {
        animation.Play(animationClip.name);
        float time = 0;
        float positionAnimateY = 0;
        float positionY = playerTransform.position.y;
        float lastKeyTime = animationCurve[animationCurve.length - 1].time;
        Vector3 cameraPosition = new Vector3(cameraTransform.position.x,cameraTransform.position.y + 3,cameraTransform.position.z);
        cameraTransform.GetComponent<FollowCamera>().enabled = false;
        while(time < lastKeyTime)
        {
            time += Time.deltaTime;
            positionAnimateY = animationCurve.Evaluate(time);
            playerTransform.position = new Vector3(playerTransform.position.x,positionY + positionAnimateY,playerTransform.position.z);
            cameraTransform.position = Vector3.Slerp(cameraPosition, new Vector3(playerTransform.position.x,cameraPosition.y + positionAnimateY,playerTransform.position.z - 12f), 15f * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        cameraTransform.GetComponent<FollowCamera>().enabled = true;
    }
}