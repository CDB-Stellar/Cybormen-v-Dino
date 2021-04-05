using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public static int Wood;
    public static int Stone;
    public static int Iron;
    public static int Electronics;

    public void Start()
    {
        GameEvents.current.OnIncrementResource += IncrementResources;
        GameEvents.current.OnEndGame += ResetResources;
    }
    private void IncrementResources(object sender, PlayerResourceEventArgs e)
    {
        Wood += e.WoodValue;
        Stone += e.StoneValue;
        Iron += e.IronValue;
        Electronics += e.ElectronicsValue;
    }
    private void ResetResources()
    {
        Wood = 0;
        Stone = 0;
        Iron = 0;
        Electronics = 0;
    }

}
