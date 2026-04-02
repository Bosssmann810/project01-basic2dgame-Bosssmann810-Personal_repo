using UnityEngine;

public class dialougeinteractable : MonoBehaviour, IInteractable
{
    public DialougeManager dialougeManager;
    bool inDialouge = false;
    public Dialouge dialouge;
    public void Focused()
    {
        //throw new System.NotImplementedException();
    }

    public void Interact()
    {
        if(inDialouge == true)
        {
            inDialouge = dialougeManager.DialougEnded();
            dialougeManager.DisplayNextText();
            return;
        }
        inDialouge = true;
        dialougeManager.StartDialouge(dialouge);
        
    }

    public void Unfocused()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
