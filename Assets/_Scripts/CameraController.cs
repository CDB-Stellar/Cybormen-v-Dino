using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Rotation");

        if (horiz > 0.1f || horiz < -0.1f)
        {
            transform.Translate(Vector3.right * horiz * cameraSpeed);
        }
        if (vert > 0.1f || vert < -0.1f)
        {
            transform.Translate(Vector3.forward * vert * cameraSpeed);
        }
        if (rot > 0.1f || rot < -0.1f)
        {
            transform.Rotate(new Vector3(0f, rotationSpeed * rot, 0f), Space.World);
        }


    }
}
