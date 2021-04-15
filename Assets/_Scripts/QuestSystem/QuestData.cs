using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestData
{
    [Header("----------------------------QUEST--------------------------------")]

    /*
        Dinosaur: 1000 + dinoaur value 
        Resource: 2000 + resource value
        Cyberman: 3001
        building construction: 4000 + tower value
        building destruction: 5000 + building value
     */
    public string questDESC;
    public int[] questCodes;
    public int questAmount;
    public PlayerResourceEventArgs reward;
    public string rewardMsg;    
}
