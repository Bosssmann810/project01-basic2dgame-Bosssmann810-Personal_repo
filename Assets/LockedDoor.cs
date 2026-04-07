using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    private bool hasKey;
    public UIManager uIManager;
    public GameObject door;

    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge lockedDialouge;
    public Dialouge unlockedDialouge;
    public void Focused()
    {
        
    }

    public void Interact()
    {
        if (inDialouge == true)
        {
            inDialouge = dialougeManager.DialougEnded();
            if(inDialouge == false && hasKey == true)
            {
                door.SetActive(false);
            }
            dialougeManager.DisplayNextText();
            return;
        }
        inDialouge = true;
        if(hasKey == true)
        {
            dialougeManager.StartDialouge(unlockedDialouge);
            
        }
        if(hasKey == false)
        {
            dialougeManager.StartDialouge(lockedDialouge);
        }
     


    }
    
    public void Unfocused()
    {
        
    }
    public void FoundKey()
    {
        hasKey = true;
    }

    void Start()
    {
        hasKey = false;
    }
    
}
