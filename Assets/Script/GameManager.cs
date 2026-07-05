using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Collectibles")]
    public bool hasTorch = false;
    public bool hasFireSuit = false;
    public bool hasChip = false;
    public bool hasBrokenChip = false;

    public event Action OnWin;

    private void Awake()
    {
        if (Instance == null)
        {
        Instance = this;
        }
        else
        {
        Destroy(gameObject);
        }
    }

    public void Collect(Collectibles.CollectibleType type)
    {
        switch (type)
        {
            case Collectibles.CollectibleType.Torch:

            hasTorch = true;
            Debug.Log("Collected Torch!");
            break; 

            case Collectibles.CollectibleType.FireSuit:

            hasFireSuit = true;
            Debug.Log("Collected Fire Suit!");
            break; 

            case Collectibles.CollectibleType.Chip:

            hasChip = true;
            Debug.Log("Collected Chip!");
            break;

            case Collectibles.CollectibleType.BrokenChip:
            hasBrokenChip = true;
            Debug.Log("Chip is replaced");
            WinGame();
            break;
        }
    }

    public void WinGame()
    {
        Debug.Log("You Win");
        OnWin?.Invoke();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}