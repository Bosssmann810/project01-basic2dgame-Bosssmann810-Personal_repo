using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    private bool hasKey;
    public UIManager uIManager;
    public GameObject door;
    public void Focused()
    {
        
    }

    public void Interact()
    {
        if(hasKey == false)
        {
            Debug.Log("It's locked. You'll need to find the key");
        }
        if(hasKey == true)
        {
            Debug.Log("You unlocked the door");
            door.SetActive(false);
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
