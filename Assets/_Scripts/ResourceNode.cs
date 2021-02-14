using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IWorkable
{
    public ResourceType nodeType;
    public float workTime;
    public float harvestAmount;
    // Start is called before the first frame update
    public bool DoWork(float currentTime)
    {
        if (currentTime >= workTime)
        {
            GameEvents.current.IncrementResource(nodeType, harvestAmount);
            return true;
        }
        else
        {
            return false;
        }
    }
}
