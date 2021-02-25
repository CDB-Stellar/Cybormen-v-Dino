using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceValueToUI : MonoBehaviour
{
    /*
     * THIS IS SHITTY TEMPORARY SCRIPT THAT IS VERY INEFFICENT
     */
    public ResourceType resourceToSet;
    private TMP_Text resourceValue;
    private void Awake()
    {
        resourceValue = GetComponent<TMP_Text>();
        Debug.Log(resourceValue);
    }
    private void Update()
    {
        switch (resourceToSet)
        {
            case ResourceType.Wood:
                resourceValue.text = PlayerResources.Wood.ToString();
                break;
            case ResourceType.Stone:
                resourceValue.text = PlayerResources.Stone.ToString();
                break;
            case ResourceType.Iron:
                resourceValue.text = PlayerResources.Iron.ToString();
                break;
            case ResourceType.Electronics:
                resourceValue.text = PlayerResources.Electronics.ToString();
                break;
            default:
                break;
        }
    }
}
