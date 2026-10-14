using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public static PlayerInventory instance;
    private int keys = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance != null) // makes sure theres only one instance of the player inventory in the scene
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddKey()
    {
        keys++;
    }

    public void RemoveKey()
    {
        keys--;
        Debug.Log(keys);
    }

    public int GetKeys()
    {
        return keys;
    }
}
