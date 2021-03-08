using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenetEnabler : MonoBehaviour
{
    public void EnableAllComponents()
    {
        Behaviour[] behaviours = GetComponentsInChildren<Behaviour>(true);
        foreach (var comp in behaviours)
        {
            comp.enabled = true;
        }
    }
}
