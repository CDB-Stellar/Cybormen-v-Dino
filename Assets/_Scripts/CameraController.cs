using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (horiz > 0.1f || horiz < -0.1f)
        {
            transform.Translate(Vector3.right * horiz * cameraSpeed);
        }
        if (vert > 0.1f || vert < -0.1f)
        {
            transform.Translate(Vector3.forward * vert * cameraSpeed, null);
        }


    }
}
