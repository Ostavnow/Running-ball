using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class MovingCameraAroundObject : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotationAngleAroundObject;
    [SerializeField]
    private float speedRotation;
    private float angleCurrent;
    private bool isRightLeft = false;
    void Update()
    {
        RotatingCameraAroundObject();
    }
    private void RotatingCameraAroundObject()
    {
        if(angleCurrent < rotationAngleAroundObject & isRightLeft)
        {
            if(0 > speedRotation)
                speedRotation = -speedRotation;
        }
        else if(angleCurrent > -rotationAngleAroundObject)
        {
            isRightLeft = false;
            if(0 < speedRotation)
                speedRotation = -speedRotation;
        }
        else
        isRightLeft = true;
        angleCurrent += Time.deltaTime * speedRotation;
        transform.RotateAround(target.position,Vector3.up, Time.deltaTime * speedRotation);
    }
}
