using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static float Wood;
    public static float Stone;
    public static float Iron;
    public static float Electronics;

    public void Start()
    {
        GameEvents.current.OnIncrementResource += HarvestResources;
    }
    private void Update()
    {

    }

    private void HarvestResources(ResourceType resource, float amount)
    {
        switch (resource)
        {
            case ResourceType.Wood:
                Wood += amount;
                break;
            case ResourceType.Stone:
                Stone += amount;
                break;
            case ResourceType.Iron:
                Iron += amount;
                break;
            case ResourceType.Electronics:
                Electronics += amount;
                break;
            default:
                break;
        }
    }
}
