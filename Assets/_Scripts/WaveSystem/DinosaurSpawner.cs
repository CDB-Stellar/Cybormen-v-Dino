using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DinosaurSpawner : MonoBehaviour
{    
    [Header("Wave Data")]
    public LayerMask dinosaurs;
    public List<DinosaurWave> Waves;

    private float currentTime = 0f;
    private List<Transform> AliveDinosaurs;
    private DinosaurWave currentWave;
    private int waveIndex = 0;
    private bool finished;
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
                Debug.Log("Finished game = " + (waveIndex == Waves.Count - 1));
                if (waveIndex == Waves.Count - 1)
                {
                    Debug.Log("Game over with victory");
                    currentWave = null;
                    finished = true;                    
                }
                else
                {
                    //Onto Next wave
                    waveIndex++;
                    currentWave = Waves[waveIndex];
                }
            }
        }
        if (finished && NoAliveDinosaurs())
        {
            GameEvents.current.EndGame(true);
        }
    }
    private bool NoAliveDinosaurs()
    {
        return !(Physics.OverlapBox(transform.position, new Vector3(50f,50f,50f), Quaternion.identity, dinosaurs).Length > 0f);
    }
}
