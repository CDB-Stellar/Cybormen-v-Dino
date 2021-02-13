using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CybermanNetwork : MonoBehaviour
{
    public List<CybermanController> ActiveCybermen;
    public Queue<CybermanTask> TaskBuffer;
    private void Awake()
    {        
        ActiveCybermen = new List<CybermanController>();
        TaskBuffer = new Queue<CybermanTask>();
    }
    private void Start()
    {
        StartCoroutine("FindCybermanWithDealy", 0.5f);

        CybermanEvents.current.QueueTask += EnqueueTask;
    }
    
    private void Update()
    {
        if (TaskBuffer.Count > 0)
        {
            for (int i = 0; i < ActiveCybermen.Count; i++)
            {
                if (ActiveCybermen[i].CurrentTask == null)
                {
                    ActiveCybermen[i].AssignTask(TaskBuffer.Dequeue());
                    break;
                }
            }
        }        
    }
    private void FindActiveCybermen()
    {
        ActiveCybermen.Clear();
        GameObject[] searchResult = GameObject.FindGameObjectsWithTag("Cyberman");
        foreach (GameObject cybermanTaggedObject in searchResult)
        {
            CybermanController c;
            if (cybermanTaggedObject.TryGetComponent(out c))
            {
                ActiveCybermen.Add(c);
            }
            else
            {
                Debug.LogError("Object Tagged Cyberman With no CybermanController");
            }
        }
    }
    private void EnqueueTask(object sender, CybermanTaskEventArgs e)
    {
        TaskBuffer.Enqueue(e.Task);
    }
    private IEnumerator FindCybermanWithDealy(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindActiveCybermen();
        }
    }
}
