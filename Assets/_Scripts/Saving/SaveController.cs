using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    [Header("Player(Camera)")]
    public CameraController player; //save player camera position

    [Header("Village")] //save the village health
    public ObjectHealth house1;
    public ObjectHealth house2;
    public ObjectHealth house3;
    public ObjectHealth house4;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    List<GameObject> currentDinos = new List<GameObject>(); //the transforms of all current dinos, to save where they are

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CameraController>();
        house1 = GameObject.Find("House").GetComponent<ObjectHealth>();
        house2 = GameObject.Find("House (1)").GetComponent<ObjectHealth>();
        house3 = GameObject.Find("House (2)").GetComponent<ObjectHealth>();
        house4 = GameObject.Find("House (3)").GetComponent<ObjectHealth>();

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
        house1.CurrentHealth = sceneData.house1;
        house2.CurrentHealth = sceneData.house2;
        house3.CurrentHealth = sceneData.house3;
        house4.CurrentHealth = sceneData.house4;

        // Load Resources
        PlayerResources.Wood = sceneData.wood;
        PlayerResources.Stone = sceneData.stone;
        PlayerResources.Iron = sceneData.iron;
        PlayerResources.Electronics = sceneData.electronics;

        // Load Dino Positions
        //currentDinos.Clear();
        //FindAllCurrentDinos(); //adds all current dinos to the currentDinos list
        //foreach (GameObject dino in currentDinos) //delete existing dinos
        //    Destroy(dino);

        //foreach (GameObject dino in sceneData.currentDinos) //bring back dinos from saved list
        //{
        //    Instantiate(dino); //this is wrong
        //}
    }

    public void OnSaveButtonPressed()
    {
        sceneData.playerPosition = player.transform.position; //save player camera position

        // Save Village Health
        sceneData.house1 = house1.CurrentHealth;
        sceneData.house2 = house2.CurrentHealth;
        sceneData.house3 = house3.CurrentHealth;
        sceneData.house4 = house4.CurrentHealth;

        // Save Resources
        sceneData.wood = PlayerResources.Wood;
        sceneData.stone = PlayerResources.Stone;
        sceneData.iron = PlayerResources.Iron;
        sceneData.electronics = PlayerResources.Electronics;

        // Save Dino Positions
        currentDinos.Clear();
        FindAllCurrentDinos(); //adds current dinos to the currentDinos list
        sceneData.currentDinos.Clear(); //empty it out in case there was a previous save
        foreach (GameObject dino in currentDinos) //add everything from currentDinos to sceneData.currentDinos
            sceneData.currentDinos.Add(dino);

        //// Save with JSON?
        //string[] saveDataString = new string[];
        //foreach (GameObject dino in sceneData.currentDinos)
        //sceneData.currentDinos.Add(dino);

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

        // Saving Resources
        PlayerPrefs.SetInt("wood", sceneData.wood);
        PlayerPrefs.SetInt("stone", sceneData.stone);
        PlayerPrefs.SetInt("iron", sceneData.iron);
        PlayerPrefs.SetInt("electronics", sceneData.electronics);
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

        // Loading Resources
        sceneData.wood = PlayerPrefs.GetInt("wood");
        sceneData.stone = PlayerPrefs.GetInt("stone");
        sceneData.iron = PlayerPrefs.GetInt("iron");
        sceneData.electronics = PlayerPrefs.GetInt("electronics");
    }

    void FindAllCurrentDinos()
    {
        // Find all active dinos and add them to the currentDinos list
        if (GameObject.FindGameObjectWithTag("MEnemy") != null)
        {
            GameObject[] mediumDinos = GameObject.FindGameObjectsWithTag("MEnemy");
            for (int i = 0; i < mediumDinos.Length; i++)
                currentDinos.Add(mediumDinos[i]);
        }
        if (GameObject.FindGameObjectWithTag("SEnemy") != null)
        {
            GameObject[] smallDinos = GameObject.FindGameObjectsWithTag("SEnemy");
            for (int i = 0; i < smallDinos.Length; i++)
                currentDinos.Add(smallDinos[i]);
        }
        if (GameObject.FindGameObjectWithTag("BEnemy") != null)
        {
            GameObject[] bigDinos = GameObject.FindGameObjectsWithTag("BEnemy");
            for (int i = 0; i < bigDinos.Length; i++)
                currentDinos.Add(bigDinos[i]);
        }
    }
}
