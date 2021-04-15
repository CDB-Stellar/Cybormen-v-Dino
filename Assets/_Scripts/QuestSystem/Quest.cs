using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public QuestData data;

    public void Start()
    {
        QuestEvents.current.OnQuestEvent += CheckQuestEvent;
    }
    private void CheckQuestEvent(int value)
    {
        foreach (int questCode in data.questCodes)
        {
            //Debug.Log(questCode + ", " + value);
            if (questCode == value)
            {
                data.questCompletion++;
                 QuestEvents.current.UpdateQuest();
                if (data.questCompletion >= data.questAmount)
                {
                    QuestEvents.current.CompleteQuest();
                }
            }
        }
    }
    private void ClaimQuestReward()
    {
        GameEvents.current.IncrementResource(this, data.reward);
    }
    private void OnDestroy()
    {
        QuestEvents.current.OnQuestEvent -= CheckQuestEvent;
    }
}
