using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWorldData", menuName ="WorldData")]
public class WorldData : ScriptableObject
{
    public int XPos;
    public int YPos;

    public void GenerateNewCoordinate()
    {
        XPos = Random.Range(0, 10000);
        YPos = Random.Range(0, 10000);
    }
}
