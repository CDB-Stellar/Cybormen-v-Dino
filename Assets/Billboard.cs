using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public string cameraName;
    private Transform cam;

    private void Awake()
    {
        cam = GameObject.Find(cameraName).transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
