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
    public EventHandler<PlayerResourceEventArgs> OnIncrementResource;
    
    public void IncrementResource(object sender, PlayerResourceEventArgs e)
    {
        OnIncrementResource?.Invoke(this, e);
    }
    public void CanBuildRequest(object sender, BuildRequestArgs e)
    {
        if (PlayerResources.Wood >= e.WoodValue &&
            PlayerResources.Stone >= e.StoneValue &&
            PlayerResources.Iron >= e.IronValue &&
            PlayerResources.Electronics >= e.ElectronicsValue)
        {
            Debug.Log("Build Request Event says enough resources");
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
