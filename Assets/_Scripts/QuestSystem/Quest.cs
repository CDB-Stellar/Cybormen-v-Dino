using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questCompletion;
    public QuestData data;

    public void Start()
    {
        QuestEvents.current.OnQuestEvent += CheckQuestEvent;
        QuestEvents.current.OnClaimReward += ClaimQuestReward;
    }
    private void CheckQuestEvent(int value)
    {
        foreach (int questCode in data.questCodes)
        {
            if (questCode == value)
            {
                questCompletion++;
                 QuestEvents.current.UpdateQuest();
                if (questCompletion >= data.questAmount)
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
        QuestEvents.current.OnClaimReward -= ClaimQuestReward;
    }
}
