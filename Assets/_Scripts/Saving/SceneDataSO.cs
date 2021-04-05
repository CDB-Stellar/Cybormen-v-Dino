using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
[System.Serializable]
public class SceneDataSO : ScriptableObject
{
    // Player Data
    [Header("Player Camera Position")]
    public Vector3 playerPosition;
    
    // Village
    [Header("Village Health")]
    public int house1;
    public int house2;
    public int house3;
    public int house4;
    
    // Resources
    [Header("Resource Counts")]
    public int wood;
    public int stone;
    public int iron;
    public int electronics;

    // Dino Positions
    public List<GameObject> currentDinos; //fix it: saves reference to object, but object is gone

    //// Towers
    //[Header("Towers")]
    //public GameObject[] towers;
}
