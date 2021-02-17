using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject objectBluePrint;

    public void SpawnObject()
    {
        Instantiate(objectBluePrint);
    }
}
