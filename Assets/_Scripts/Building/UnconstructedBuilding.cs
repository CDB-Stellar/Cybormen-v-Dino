using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnConstructedBuilding : MonoBehaviour, IWorkable
{
    public float buildTime;
    public float riseRate;
    public Transform building;

    private ComponenetEnabler enabler;
    private bool isBuilding;

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
    private void Start()
    {
        CybermanEvents.current.EnqueueTask(new CybermanTask(transform, this));
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
                building.position = new Vector3(building.position.x, 0f, building.position.z);
                enabler = building.GetComponent<ComponenetEnabler>();
                enabler.EnableAllComponents();

                building.parent = null;
                Destroy(gameObject);            
            }
        }
    }
}
