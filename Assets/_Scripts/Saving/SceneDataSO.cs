using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
[System.Serializable]
public class SceneDataSO : ScriptableObject
{
    // Player Data
    [Header("Player Data")]
    public Vector3 playerPosition;
    // Village
    [Header("Village")]
    public int house1;
    public int house2;
    public int house3;
    public int house4;
    // Resources
    [Header("Resources")]
    public int wood;
    public int rock;
    public int iron;
    public int electronics;
    // Towers
    [Header("Towers")]
    public GameObject[] towers;
}
