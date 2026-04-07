using UnityEngine;

public class InteractableKey : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LockedDoor door;
    public void Focused()
    {
        //throw new System.NotImplementedException();
    }
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge dialouge;
    public void Interact()
    {
        if (inDialouge == true)
        {
            inDialouge = dialougeManager.DialougEnded();
            if(inDialouge == false)
            {
                door.FoundKey();
                Destroy(this.gameObject);
            }
            dialougeManager.DisplayNextText();
            return;
        }
        inDialouge = true;
        dialougeManager.StartDialouge(dialouge);
        Debug.Log("You found a key");

        

    }

    public void Unfocused()
    {
       // throw new System.NotImplementedException();
    }
}
