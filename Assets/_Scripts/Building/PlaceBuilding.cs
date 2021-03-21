using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject objectBluePrint;
    private ResourceAmounts constructionCost;

    private void Awake()
    {
        constructionCost = objectBluePrint.GetComponent<ResourceAmounts>();
    }
    public void SpawnObject()
    {
        BuildRequestArgs cost = new BuildRequestArgs(constructionCost.wood, constructionCost.stone, constructionCost.iron, constructionCost.electronics);
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
