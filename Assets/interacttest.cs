using UnityEngine;

public class interacttest : MonoBehaviour, IInteractable
{
    public void Focused()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Interact()
    {
        Debug.Log("sucsess");      
    }

    public void Unfocused()
    {
        
    }
}
