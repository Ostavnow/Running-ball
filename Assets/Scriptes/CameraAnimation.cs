using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    public void PlayAnimation()
    {
        StartCoroutine(Animate());
    }
    private IEnumerator Animate()
    {
        float time = 0;
        while(time < 1)
        {
            time = Time.deltaTime;
            cameraTransform.position = Vector3.Slerp(cameraTransform.position,transform.position,time);
            cameraTransform.eulerAngles = Vector3.Slerp(cameraTransform.eulerAngles,transform.eulerAngles,time);
            yield return null;
        }
    }
}
