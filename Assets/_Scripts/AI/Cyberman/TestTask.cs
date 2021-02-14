using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTask : MonoBehaviour
{
    public bool assignTask;
    public Transform taskPosition;
    public IWorkable task;
    public CybermanController cyberman;
    // Start is called before the first frame update
    void Start()
    {
        task = GameObject.Find("IronNode").GetComponent<ResourceNode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (assignTask)
        {
            Debug.Log(taskPosition);
            CybermanTask newtask = new CybermanTask(taskPosition, task);
            cyberman.AssignTask(newtask);
            assignTask = false;
            
        }
    }
}
