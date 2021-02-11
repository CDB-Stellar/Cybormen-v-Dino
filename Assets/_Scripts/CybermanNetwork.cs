using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CybermanNetwork : MonoBehaviour
{
    public static CybermanNetwork current;
    public static float maxCyberman;
    public List<CybermenController> currentCybermen;

    public Action OnUnloadInventory;
    IEnumerator FindCybermen(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("Coroutine");
            FindActiveCybermen();
        }
    }
    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        StartCoroutine("FindCybermen", 0.5f);
    }
    public void AddTask()
    {
        Debug.Log("Added Job");
    }
    public void UnloadAInventory()
    {
        OnUnloadInventory?.Invoke();
    }
    private void FindActiveCybermen()
    {
        currentCybermen.Clear();
        currentCybermen.AddRange(FindObjectsOfType<CybermenController>());
        foreach (var item in currentCybermen)
        {
            Debug.Log("Fuck");
        }
    }
}
