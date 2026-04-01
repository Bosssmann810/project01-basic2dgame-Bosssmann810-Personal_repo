using UnityEngine;
using UnityEngine.InputSystem;

public class InteractManager : MonoBehaviour
{
    
    [SerializeField] private IInteractable interactTarget;
    [SerializeField] private GameObject targetobject;
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (interactTarget == null)
            {
                Debug.Log("nothing to interact with");
                return;
            }
            interactTarget.Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetobject = collision.gameObject;
            interactTarget = foundInteractable;
            interactTarget.Focused();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetobject = null;
            interactTarget.Unfocused();
            interactTarget = null;
        }
    }
}
