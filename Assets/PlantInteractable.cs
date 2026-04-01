using UnityEngine;
using UnityEngine.Rendering;

public class PlantInteractable : MonoBehaviour, IInteractable
{
    void IInteractable.Focused()
    {
        //throw new System.NotImplementedException();
    }

    void IInteractable.Interact()
    {
        Debug.Log("you watered the plant... it be a real shame if the quest wasnt implamented yet");
        Debug.Log("cough");
        //advance skullys dialouge here...
    }



    void IInteractable.Unfocused()
    {
        //throw new System.NotImplementedException();
    }


}
