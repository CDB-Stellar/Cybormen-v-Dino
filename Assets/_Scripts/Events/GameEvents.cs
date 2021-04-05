using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public EndData endData; 
    private void Awake()
    {
        current = this;
    }

    public EventHandler<BuildRequestArgs> OnBuildRequest;
    public EventHandler<PlayerResourceEventArgs> OnIncrementResource;
    public Action OnPlaceBuilding, OnCancelBuilding;
    
    public void IncrementResource(object sender, PlayerResourceEventArgs e)
    {
        OnIncrementResource?.Invoke(this, e);
    }
    public void CanBuildRequest(object sender, BuildRequestArgs e)
    {
        int woodNeeded = PlayerResources.Wood - e.WoodValue,
        stoneNeeded = PlayerResources.Stone - e.StoneValue,
        ironNeeded = PlayerResources.Iron - e.IronValue,
        electronicsNeeded = PlayerResources.Electronics - e.ElectronicsValue;
        string notification = "";        

        if (woodNeeded < 0)
        {
            notification += String.Format("Need {0} more Wood.\n", -woodNeeded);
        }
        if (stoneNeeded < 0)
        {
            notification += String.Format("Need {0} more Stone.\n", -stoneNeeded);
        } 
        if(ironNeeded < 0)
        {
            notification += String.Format("Need {0} more Iron.\n", -ironNeeded);
        }
        if(electronicsNeeded < 0)
        {
            notification += String.Format("Need {0} more Electronics.\n", -electronicsNeeded);
        }

        if (notification.Equals(""))
        {
            Debug.Log("Build Request Event says enough resources" + ", " + woodNeeded);
            e.CanBuild = true;                    
        }
        else
        {
            Debug.Log(notification);
            NotificationManager.current.SetNewNotifcation(notification);
        }
    }
    public void PlaceBuilding()
    {
        OnPlaceBuilding?.Invoke();
    }
    public void CancelBuilding()
    {
        OnCancelBuilding?.Invoke();
    }
    public void EndGame(bool isWin)
    {        
        if (isWin)
        {
            endData.gameOverMsg = "You are Victorious!";
        }
        else
        {
            endData.gameOverMsg = "The Village has Crumbled...";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
