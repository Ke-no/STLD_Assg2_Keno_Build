using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool hasTorch;
    public bool hasFireSuit;
    public bool hasChip;
    public bool hasBrokenChip;

    public event Action OnWin;

    private void Awake()
    {
        if (Instance == null)
        Instance = this;
        else
        Destroy(gameObject);
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

            if (hasChip)
                {
                    hasBrokenChip = true;
                    Debug.Log("Chip Replaced Successfully!");
                    WinGame();
                }
                else
                {
                    Debug.Log("You need a new chip first.");
                }
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