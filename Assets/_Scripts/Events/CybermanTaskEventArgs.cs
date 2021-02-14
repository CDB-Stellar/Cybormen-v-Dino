using System;
using UnityEngine;

public class CybermanTaskEventArgs : EventArgs
{
    public CybermanTask Task { get; }
    public CybermanTaskEventArgs(CybermanTask task)
    {
        Task = task;
    }
}

