using System.Data.SqlTypes;
using UnityEngine;

public class ExitSkull : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge firstDialouge;
    public Dialouge secondDialouge;
    public Dialouge questCompleteDialouge;
    public Dialouge postQuestDialouge;
    public bool alreadyTalkedTo = false;
    public bool questComplete = false;
    public QuestManager questManager;
    bool questFinished = false;
    public UIManager uimanager;
    bool alreadyComplete = false;
    public void Focused()
    {
        //throw new System.NotImplementedException();
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
        if (questFinished == true)
        {
            uimanager.WinGame();
            return;
        }
        if (alreadyTalkedTo == false)
        {
            dialougeManager.StartDialouge(firstDialouge);
            alreadyTalkedTo = true;
            return;
        }
        if (alreadyTalkedTo == true && questComplete == false)
        {
            dialougeManager.StartDialouge(secondDialouge);
            return;
        }
        if (questComplete == true)
        {
            dialougeManager.StartDialouge(questCompleteDialouge);
            questManager.AdvanceQuest();
            questFinished = true;
            return;
        }


    }
    public void CompleteQuest()
    {
        questComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
   
            if (questManager.TotalCompleted() >= 5)
            {
                
                alreadyComplete = true;
                uimanager.UpdateQuestText("All Quests Complete");
                CompleteQuest();
            }
        
    }

    public void Unfocused()
    {
       // throw new System.NotImplementedException();
    }
}
