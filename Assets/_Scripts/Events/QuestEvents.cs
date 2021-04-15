using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvents : MonoBehaviour
{
    public static QuestEvents current;

    public Quest currentQuest;
    public List<QuestData> questPool;

    public Action<int> OnQuestEvent;
    public Action OnQuestComplete, OnQuestUpdate, OnClaimReward;
    public Action OnNewQuest;

    private void Awake()
    {
        current = this;
        GetNewQuest();
    }
    public void QuestEvent(int questValue)
    {
        Debug.Log(questValue);
        OnQuestEvent?.Invoke(questValue);
    }
    public void UpdateQuest()
    {
        OnQuestUpdate?.Invoke();
    }
    public void CompleteQuest()
    {
        OnQuestComplete?.Invoke();
    }
    public void ClaimReward()
    {
        GetNewQuest();
        OnClaimReward?.Invoke();
    }
    private void GetNewQuest()
    {
        System.Random random = new System.Random();

        int value = random.Next(0, questPool.Count - 1);
        Debug.Log(questPool.Count);
        currentQuest.data = questPool[value];
        currentQuest.questCompletion = 0;
        OnNewQuest?.Invoke();
    }
}
