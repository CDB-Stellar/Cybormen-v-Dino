using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CybermanTask
{
    public IWorkable Work { get; }
    public Transform TaskLocation { get; }
    public CybermanTask(Transform taskLocation, IWorkable work)
    {
        TaskLocation = taskLocation;
        Work = work;
    }
}

