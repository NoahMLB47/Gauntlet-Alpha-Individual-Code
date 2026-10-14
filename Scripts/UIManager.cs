using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] keyInventoryDisplay;
    private static int nextKey = 0;
    public static UIManager instance;
    [SerializeField] private GameObject startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        if (instance != null) // singleton
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        instance.RefreshKeyDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RefreshKeyDisplay() // show one icon for each key in the inventory and hide the rest
    {
        for (int i = 0; i < keyInventoryDisplay.Length; i++)
            if (keyInventoryDisplay[i] != null)
                keyInventoryDisplay[i].SetActive(i < nextKey);
    }
    public void addKeyToInventory()
    {
        nextKey ++;
        instance.RefreshKeyDisplay();
    }

    public void removeKeyFromInventory()
    {
        if (nextKey <= 0) return;
        nextKey --;
        instance.RefreshKeyDisplay();
    }
    public void ResetKeys()
    {
        nextKey = 0;
        instance.RefreshKeyDisplay();
    }
    public void ShowStartButton()
    {
        if (startButton != null)
            startButton.SetActive(true);
    }
}
