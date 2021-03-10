using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTask : MonoBehaviour, IWorkable
{
    public int BuildingLayer;
    public float buildTime;
    public float riseRate;
    public Transform building;

    private ObjectHealth buildingHealth;
    private ProjectileSystem tower = null;
    private bool isBuilding;

    private void Awake()
    {
        buildingHealth = transform.GetChild(0).GetComponent<ObjectHealth>();
        // THIS IS REALLY BAD FIX IT LATER
        transform.GetChild(0).TryGetComponent(out tower);
    }
    private void Start()
    {
        CybermanEvents.current.EnqueueTask(new CybermanTask(transform, this));
    }
    public bool DoWork(float currentTime)
    {
        if (currentTime > buildTime)
        {
            isBuilding = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isBuilding)
        {
            if (building.position.y < -0.1f)
            {
                building.Translate(new Vector3(0f, riseRate, 0f));
            }
            else
            {
                // FIX THIS YOU FUCKER ITS AWFULL
                if (tower != null)
                    tower.ActivateTower();
                building.position = new Vector3(building.position.x, 0f, building.position.z);
                buildingHealth.InitalizeHealthBar();
                building.gameObject.layer = BuildingLayer;
                building.parent = null;
                Destroy(gameObject);
            }
        }
    }
}
