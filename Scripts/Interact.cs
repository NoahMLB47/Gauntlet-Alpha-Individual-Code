using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    IInteractable currentTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.TryGetComponent<IInteractable>(out var interactable)) // checks if the object colliding with the player is interactable
        {
            Debug.Log("found target");
            currentTarget = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out var interactable) && currentTarget == interactable)
        {
            currentTarget = null;
        }
    }

    public void onInteract(InputAction.CallbackContext context)
    {
        if (currentTarget != null) // checks if the player is in range of an interactable object
        {
            currentTarget.onInteract();
        }
    }
}
