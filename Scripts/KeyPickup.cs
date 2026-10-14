using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    
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
        if(collision.CompareTag("Key")) // checks if the object colliding with the player is a key
        {
            GameObject key = collision.gameObject;
            PlayerInventory.instance.AddKey();
            UIManager.instance.addKeyToInventory();
            Destroy(key);
        }
    }
}
