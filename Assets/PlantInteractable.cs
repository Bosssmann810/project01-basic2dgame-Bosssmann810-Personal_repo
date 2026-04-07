using UnityEngine;
using UnityEngine.Rendering;

public class PlantInteractable : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge dialouge;
    public SkullyDiolouge skully;
    bool TalkedTo = false;
    public Dialouge repeatedInteractionDialouge;
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
        if (TalkedTo == false)
        {
            dialougeManager.StartDialouge(dialouge);
            skully.CompleteQuest();
            TalkedTo = true;
            return;
        }
        if(TalkedTo = true)
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
