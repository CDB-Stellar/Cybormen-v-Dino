using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public WorldData worldData;
    void Start()
    {
        worldData.GenerateNewCoordinate();
    }
}
