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

    public Action<ResourceType, float> OnIncrementResource;
    
    public void IncrementResource(ResourceType resource, float amount)
    {
        OnIncrementResource?.Invoke(resource, amount);
    }
}
