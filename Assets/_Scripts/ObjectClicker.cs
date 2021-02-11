using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public LayerMask clickableMask;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, clickableMask))
            {
                if (hit.transform)
                {
                    PrintName(hit.transform.gameObject);
                    CybermanNetwork.current.AddTask();
                }
            } 
        }
    }
    private void PrintName(GameObject obj)
    {
        print(obj.name);
    }
}
