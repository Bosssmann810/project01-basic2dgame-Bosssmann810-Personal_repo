using UnityEngine;

public class SkullyDiolouge : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge firstDialouge;
    public Dialouge secondDialouge;
    public Dialouge questCompleteDialouge;
    public bool alreadyTalkedTo = false;
    public bool questComplete = false;
    
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
        if(alreadyTalkedTo == false && questComplete ==false)
        {
            dialougeManager.StartDialouge(firstDialouge);
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
