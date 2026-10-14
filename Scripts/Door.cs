using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    SpriteRenderer sr;
    [SerializeField] private Sprite doorOpen;
    [SerializeField] private Sprite doorClosed;
    BoxCollider2D hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onInteract()
    {
        int keys = PlayerInventory.instance.GetKeys();

        if (keys > 0)
        {
            Debug.Log("interacted Via Key");
            PlayerInventory.instance.RemoveKey();
            UIManager.instance.removeKeyFromInventory();

            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        sr.sprite = doorOpen;
        hitbox.enabled = false;
        Debug.Log("Door Opened");
    }
}


