using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestData
{
    public string questDescription;
    /*
        Dinosaur: 1000 + dinoaur value 
        Resource: 2000 + resource value
        Cyberman: 3001
        tower: 4000 + tower value
     */
    public int[] questCodes;
    public int questAmount;
    public int questCompletion;
    public PlayerResourceEventArgs reward;
}
