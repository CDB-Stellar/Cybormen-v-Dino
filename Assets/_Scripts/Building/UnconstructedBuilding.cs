using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnconstructedBuilding : MonoBehaviour
{
    public GameObject prefab;
    public LayerMask placeLayer;
    public string cameraName;
    
    private Camera camera; 
    private RaycastHit hit;

    private void Awake()
    {
        camera = GameObject.Find(cameraName).GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5000000.0f, placeLayer))
        {
            transform.position = hit.point;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}