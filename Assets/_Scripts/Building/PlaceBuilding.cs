using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject objectBluePrint;
    public float wood;
    public float stone;
    public float iron;
    public float electronics;

    public void SpawnObject()
    {
        BuildRequestArgs cost = new BuildRequestArgs(wood, stone, iron, electronics);
        GameEvents.current.CanBuildRequest(this, cost);

        //Debug.Log(cost.CanBuild);

        if (cost.CanBuild)
        {
            Instantiate(objectBluePrint);
        }
        else
        {
            Debug.LogWarning("Not Enough Resources to build");
        }
    }
}
