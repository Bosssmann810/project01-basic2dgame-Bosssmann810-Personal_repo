using UnityEngine;
using UnityEngine.Rendering;

public class QuestItemInteractable : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge dialouge;
    public SkullyDiolouge questGiver;
    bool TalkedTo = false;
    public Dialouge repeatedInteractionDialouge;
    public QuestManager questManager;

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
        if (questManager.GetCurrentQuest() == questGiver.quest)
        {
            if(TalkedTo == true)
            {
                dialougeManager.StartDialouge(repeatedInteractionDialouge);
                return;
            }
            dialougeManager.StartDialouge(dialouge);
            questManager.AdvanceQuest();
            questGiver.CompleteQuest();
            TalkedTo = true;
            return;
        }
        if(questManager.GetCurrentQuest() != questGiver.quest)
        {
            dialougeManager.StartDialouge(repeatedInteractionDialouge);
            return;
        }
        

    }

    public void Unfocused()
    {
        //throw new System.NotImplementedException();
    }


}
