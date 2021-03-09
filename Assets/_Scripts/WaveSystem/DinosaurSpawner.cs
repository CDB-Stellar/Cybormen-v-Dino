using System;
using System.Collections.Generic;
using UnityEngine;


public class DinosaurSpawner : MonoBehaviour
{    
    [Header("Wave Data")]
    public List<DinosaurWave> Waves;

    private float currentTime = 0f;
    private List<Transform> AliveDinosaurs;
    private DinosaurWave currentWave;
    private int waveIndex = 0;
    void Start()
    {
        currentWave = Waves[waveIndex];
    }
    void FixedUpdate()
    {
        currentTime = (float)Math.Round(Time.time, 2);
        if (currentWave != null && currentTime != 0)
        {
            foreach (DinoSpawn data in currentWave.waveContents)
            {
                //Debug.Log(string.Format($"Current Time: "+currentTime+" divided by spawnRate: "+ data.spawnRate + ", has remainder of " + currentTime % data.spawnRate));
                if (currentTime != 0 && currentTime % data.spawnRate <= 0.01f)
                {
                    for (int i = 0; i < data.spawnAmount; i++)
                    {
                        data.SpawnDinosaur();
                        //Debug.Log("Spawn at " + currentTime + " i :" + i);
                    }
                }
            }
            //if wave is done go to next wave
            if (currentTime % currentWave.waveTime <= 0.01f)
            {
                if (waveIndex == Waves.Count - 1)
                {
                    currentWave = null;
                    //Check all dinosaurs are dead
                    if (NoAliveDinosaurs())
                    {
                        // Congrats you win
                    }
                }
                else
                {
                    //Onto Next wave
                    waveIndex++;
                    currentWave = Waves[waveIndex];
                }
            }
        }        
    }
    private bool NoAliveDinosaurs()
    {
        return !(Physics.OverlapBox(transform.position, new Vector3(50f,50f,50f), Quaternion.identity).Length > 0f);
    }
}
