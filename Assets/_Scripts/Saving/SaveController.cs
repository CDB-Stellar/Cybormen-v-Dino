using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [Header("Player(Camera)")]
    public CameraController player;

    [Header("Village")]
    public GameObject house1;
    public ObjectHealth house2;
    public ObjectHealth house3;
    public ObjectHealth house4;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    // Start is called before the first frame update
    void Start()
    {
        LoadFromPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoadButtonPressed()
    {
        // Deserialize/load data from player prefs once - in the Start()
        LoadFromPlayerPrefs();

        player.transform.position = sceneData.playerPosition; //load player camera position

        // Load Village Health
        house1.GetComponent<ObjectHealth>().CurrentHealth = sceneData.house1;
        house2.CurrentHealth = sceneData.house2;
        house3.CurrentHealth = sceneData.house3;
        house4.CurrentHealth = sceneData.house4;
    }

    public void OnSaveButtonPressed()
    {
        sceneData.playerPosition = player.transform.position; //save player camera position

        // Save Village Health
        sceneData.house1 = house1.GetComponent<ObjectHealth>().CurrentHealth;
        sceneData.house2 = house2.CurrentHealth;
        sceneData.house3 = house3.CurrentHealth;
        sceneData.house4 = house4.CurrentHealth;

        SaveToPlayerPrefs();
    }

    public void SaveToPlayerPrefs()
    {
        // Serialize/save data to PlayerPrefs dictionary
        //PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(sceneData));

        // Saving Player Camera Position
        PlayerPrefs.SetFloat("playerTransformX", sceneData.playerPosition.x);
        PlayerPrefs.SetFloat("playerTransformY", sceneData.playerPosition.y);
        PlayerPrefs.SetFloat("playerTransformZ", sceneData.playerPosition.z);

        // Saving Village Health
        PlayerPrefs.SetInt("house1Health", sceneData.house1);
        PlayerPrefs.SetInt("house2Health", sceneData.house2);
        PlayerPrefs.SetInt("house3Health", sceneData.house3);
        PlayerPrefs.SetInt("house4Health", sceneData.house4);
    }

    public void LoadFromPlayerPrefs()
    {
        // Deserialize/load data from PlayerPrefs
        //JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("PlayerData"), sceneData);

        // Loading Player Camera Position
        sceneData.playerPosition.x = PlayerPrefs.GetFloat("playerTransformX");
        sceneData.playerPosition.y = PlayerPrefs.GetFloat("playerTransformY");
        sceneData.playerPosition.z = PlayerPrefs.GetFloat("playerTransformZ");

        // Loading Village Health
        sceneData.house1 = PlayerPrefs.GetInt("house1Health");
        sceneData.house2 = PlayerPrefs.GetInt("house2Health");
        sceneData.house3 = PlayerPrefs.GetInt("house3Health");
        sceneData.house4 = PlayerPrefs.GetInt("house4Health");
    }
}
