using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private void Start()
    {
        animation = GetComponent<Animator>();
        playerTransform = FindObjectOfType<PlayerController>().transform;
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            StartCoroutine(Animation());
            audioManager.Play("spring");
        }
    }
    private IEnumerator Animation()
    {
        animation.Play(animationClip.name);
        float time = 0;
        float positionAnimateY = 0;
        float positionY = playerTransform.position.y;
        float lastKeyTime = animationCurve[animationCurve.length - 1].time;
        while(time < lastKeyTime)
        {
            time += Time.deltaTime;
            positionAnimateY = animationCurve.Evaluate(time);
            playerTransform.position = new Vector3(playerTransform.position.x,positionY + positionAnimateY,playerTransform.position.z);  
            yield return null;
        }
    }
}
