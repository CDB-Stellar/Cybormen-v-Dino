using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }

    public EventHandler<BuildRequestArgs> OnBuildRequest;
    public Action<ResourceType, float> OnIncrementResource;
    
    public void IncrementResource(ResourceType resource, float amount)
    {
        OnIncrementResource?.Invoke(resource, amount);
    }
    public void CanBuildRequest(object sender, BuildRequestArgs e)
    {
        if (PlayerResources.Wood >= e.WoodCost && PlayerResources.Stone >= e.StoneCost && PlayerResources.Iron >= e.IronCost && PlayerResources.Electronics >= e.ElectronicsCost)
        {
            Debug.Log("Build Request Event says enough resources");

            IncrementResource(ResourceType.Wood, -e.WoodCost);
            IncrementResource(ResourceType.Stone, -e.StoneCost);
            IncrementResource(ResourceType.Iron, -e.IronCost);
            IncrementResource(ResourceType.Electronics, -e.ElectronicsCost);

            e.CanBuild = true;
        }
        else
        {
            Debug.Log("Build Request Event says not enough resources");
            e.CanBuild = false;
        }
    }
    public void WinGame()
    {

    }
}
