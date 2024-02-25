using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    private Material material;
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    public void RedColorMaterial()
    {
       material.color = new Color(255,0,0,255);
    }
}
