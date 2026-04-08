using UnityEngine;

public class SkullyDiolouge : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge firstDialouge;
    public Dialouge secondDialouge;
    public Dialouge questCompleteDialouge;
    public Dialouge busyDialouge;
    public Dialouge postQuestDialouge;
    public bool alreadyTalkedTo = false;
    public bool questComplete = false;
    public QuestManager questManager;
    public Quest quest;
    bool questFinished = false;

    public void Focused()
    {
        //throw new System.NotImplementedException();
    }
    public bool GetFinishedStatus()
    {
        return questFinished;
    }
    public void Interact()
    {
        if (inDialouge == true)
        {
            inDialouge = dialougeManager.DialougEnded();
            dialougeManager.DisplayNextText();
            return;
        }
        inDialouge = true;
        if(questFinished == true)
        {
            dialougeManager.StartDialouge(postQuestDialouge);
            return;
        }
        if(questManager.InQuest() && questManager.GetCurrentQuest() != quest)
        {
            dialougeManager.StartDialouge(busyDialouge);
            return;
        }
        if(alreadyTalkedTo == false && questComplete ==false && questManager.InQuest() == false)
        { 
            dialougeManager.StartDialouge(firstDialouge);
            Debug.Log(quest);
            questManager.StartQuest(quest);
            alreadyTalkedTo = true;
            return;
        }
        if(alreadyTalkedTo == true && questComplete == false)
        {
            dialougeManager.StartDialouge(secondDialouge);
            return;
        }
        if(questComplete == true)
        {
            dialougeManager.StartDialouge(questCompleteDialouge);
            questManager.AdvanceQuest();
            questManager.CompletedQuest();
            questFinished = true;
            return;
        }
        

    }
    public void CompleteQuest()
    {
        questComplete = true;
    }
    public void Unfocused()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alreadyTalkedTo = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
