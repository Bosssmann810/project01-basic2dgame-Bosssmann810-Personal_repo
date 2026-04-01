using UnityEngine;

public class InteractableKey : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LockedDoor door;
    public void Focused()
    {
        //throw new System.NotImplementedException();
    }

    public void Interact()
    {
        Debug.Log("You found a key");
        door.FoundKey();
        Destroy(this.gameObject);
    }

    public void Unfocused()
    {
       // throw new System.NotImplementedException();
    }
}
