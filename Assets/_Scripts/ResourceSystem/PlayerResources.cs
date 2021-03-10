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
