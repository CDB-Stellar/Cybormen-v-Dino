using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IWorkable
{
   
    public float workTime;
    public bool usesDurability;

    private ObjectHealth health;
    private ResourceAmounts resources;
    private PlayerResourceEventArgs e;
    private void Awake()
    {
        health = GetComponent<ObjectHealth>();
        resources = GetComponent<ResourceAmounts>();
    }
    private void Start()
    {
        e = new PlayerResourceEventArgs(resources.wood, resources.stone, resources.iron, resources.electronics);
    }
    public bool DoWork(float currentTime)
    {
        if (currentTime >= workTime)
        {
            GameEvents.current.IncrementResource(this, e);
            if (usesDurability) health.TakeDamage(1);
            return true;
        }
        else
        {
            return false;
        }
    }
}
