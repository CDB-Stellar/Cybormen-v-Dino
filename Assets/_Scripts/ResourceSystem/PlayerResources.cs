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
    }
    private void IncrementResources(object sender, PlayerResourceEventArgs e)
    {
        Wood += e.WoodValue;
        Stone += e.StoneValue;
        Iron += e.IronValue;
        Electronics += e.ElectronicsValue;
    }
}
