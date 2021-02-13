using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IWorkable
{
    public float workTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool DoWork(float currentTime)
    {
        if (currentTime >= workTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
