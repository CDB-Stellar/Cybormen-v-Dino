using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    Transform[] buildings;
    void Awake()
    {
        buildings = GetComponentsInChildren<Transform>();
        //foreach (transform item in buildings)
        //{
        //    debug.log(item.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach (Transform transform in buildings)
        {
            if (transform == null)
            {
                count++;
            }
        }
        if (count == buildings.Length - 1)
        {
            GameEvents.current.EndGame(false);
        }
    }
}
