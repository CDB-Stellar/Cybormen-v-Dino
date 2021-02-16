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

    public EventHandler<CybermanTaskEventArgs> QueueTask;

    public void EnqueueTask(CybermanTask cybermanTask)
    {
        QueueTask?.Invoke(this, new CybermanTaskEventArgs(cybermanTask));
    }
}
