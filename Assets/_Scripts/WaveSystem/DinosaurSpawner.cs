using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurSpawner : MonoBehaviour
{    
    [Header("Wave Data")]
    public List<DinosaurWave> Waves;

    private float currentTime = 0f;
    private DinosaurWave currentWave;
    void Start()
    {
        currentWave = Waves[0];
    }
    void Update()
    {
        currentTime = Time.time;

        foreach (DinoSpawn data in currentWave.waveContents)
        {
            //Debug.Log(string.Format($"Current Time: "+currentTime+" divided by spawnRate: "+ data.spawnRate + ", has remainder of " + currentTime % data.spawnRate));
            if (Mathf.Approximately(currentTime % data.spawnRate, 0.0f))
            {
                for (int i = 0; i < data.spawnAmount; i++)
                {
                    data.SpawnDinosaur();
                    Debug.Log("Spawn at " + currentTime);
                }                     
            }            
        }       
    }
}
