using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IWorkable
{
    public ResourceType nodeType;
    public float workTime;
    public float harvestAmount;

    private ObjectHealth health;
    private void Awake()
    {
        health = GetComponent<ObjectHealth>();
    }
    public bool DoWork(float currentTime)
    {
        if (currentTime >= workTime)
        {
            GameEvents.current.IncrementResource(nodeType, harvestAmount);
            if (nodeType != ResourceType.Electronics) health.TakeDamage(1);
            return true;
        }
        else
        {
            return false;
        }
    }
}
