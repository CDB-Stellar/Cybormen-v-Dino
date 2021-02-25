using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public LayerMask clickableMask;
    public string cameraName;

    private Camera camera;
    private void Awake()
    {
        camera = GameObject.Find(cameraName).GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, clickableMask))
            {
                Debug.Log("Adding Resource Task");
                IWorkable resource = hit.collider.gameObject.GetComponent<IWorkable>();
                CybermanEvents.current.EnqueueTask(new CybermanTask(hit.transform, resource));
            } 
        }
    }
}
