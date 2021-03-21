using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CybermanEvents : MonoBehaviour
{
    public static CybermanEvents current;
    void Awake()
    {
        current = this;
    }

    public EventHandler<CybermanTaskEventArgs> OnQueueTask;
    public EventHandler<EventArgs> OnClearTasks;

    public void EnqueueTask(CybermanTask cybermanTask)
    {
        OnQueueTask?.Invoke(this, new CybermanTaskEventArgs(cybermanTask));
    }
    public void ClearTasks()
    {
        OnClearTasks?.Invoke(this, new EventArgs());
    }
}
