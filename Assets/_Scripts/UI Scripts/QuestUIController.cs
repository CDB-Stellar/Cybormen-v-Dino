using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIController : MonoBehaviour
{
    // Assumes there is one quest at a time

    public TextMeshProUGUI description; //quest info
    public TextMeshProUGUI reward; //reward amount and item
    public TextMeshProUGUI completeness; //completeness counter
    public GameObject claimRewardButton; //replaces the completeness counter
    public GameObject questInfoPanel; //turn it off or on if you have a quest or not
    public TextMeshProUGUI noQuest; //tells user no quest active
    public Quest currentQuest;

    private void Awake()
    {
        QuestEvents.current.OnQuestUpdate += UpdateQuest;
        QuestEvents.current.OnQuestComplete += QuestComplete;
        QuestEvents.current.OnNewQuest += CreateQuest;
    }
    private void Start()
    {
        // Make sure the right thing is enabled at the start
        completeness.enabled = true;
        claimRewardButton.SetActive(false);
        UpdateQuest();
    }

    public void UpdateQuest()
    {
        Quest quest = QuestEvents.current.currentQuest;
        UpdateDescription(quest.data.questDESC);
        UpdateCompleteness(quest.questCompletion, quest.data.questAmount);
        UpdateReward(quest.data.rewardMsg);
    }

    // Function to change the quest description text. Can be a sentence or two.
    public void UpdateDescription(string description)
    {
        this.description.text = description;
    }

    // Function to change the reward text. Ex. (5, wood)
    public void UpdateReward(string rewardMessage)
    {
        reward.text = "Reward: " + rewardMessage;
    }

    // Function to change the fraction representing completeness (x/y)
    public void UpdateCompleteness(int x, int y)
    {
        completeness.text = x + " / " + y;
    }

    // Function to replace completeness counter with the claim button
    public void QuestComplete()
    {
        completeness.enabled = false;
        claimRewardButton.SetActive(true);
    }

    // Deactivates the quest info panel if quest is done
    public void NoQuest()
    {
        questInfoPanel.SetActive(false);
        noQuest.enabled = true;
    }

    // Can use this to create a new quest with everything at once
    public void CreateQuest()
    {
        noQuest.enabled = false;
        completeness.enabled = true;
        claimRewardButton.SetActive(false);
        questInfoPanel.SetActive(true);
        UpdateQuest();
    }
}
