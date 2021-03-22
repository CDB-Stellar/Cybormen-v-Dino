using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    public GameObject joystick;

    private FixedJoystick control;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Awake()
    {
        control = joystick.GetComponent<FixedJoystick>();
    }
    void Update()
    {
        /*
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Rotation");
        */

        float horiz = control.Horizontal;
        float vert = control.Vertical;

        if (horiz > 0.1f || horiz < -0.1f)
        {
            transform.Translate(Vector3.right * horiz * movementSpeed);
        }
        if (vert > 0.1f || vert < -0.1f)
        {
            transform.Translate(Vector3.forward * vert * movementSpeed);
        }
        //if (rot > 0.1f || rot < -0.1f)
        //{
        //    transform.rotate(new vector3(0f, rotationspeed * rot, 0f), space.world);
        //}


    }
}
