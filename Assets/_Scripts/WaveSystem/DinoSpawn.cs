using System;
using UnityEngine;


[Serializable]
public class DinoSpawn
{
    public GameObject dinosaur;
    public float spawnAmount;
    public float spawnRate;
    public Transform spawnLocation;
    public bool CanSpawn;
    
    public void SpawnDinosaur()
    {
        UnityEngine.Object.Instantiate(dinosaur, spawnLocation.position, Quaternion.identity);
        CanSpawn = false;
    }
}
