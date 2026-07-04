using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Text")]
    public TextMeshProUGUI promptText;
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI healthText;

    [Header("References")]
    public PlayerHealth playerHealth;

    [Header("Panels")]
    public GameObject winPanel;
    public GameObject gameOverPanel;

    void Start()
    {
        if(winPanel != null)
        winPanel.SetActive(false);

        if(gameOverPanel != null)
        gameOverPanel.SetActive(false);

        if(playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealth;
            playerHealth.OnDie += ShowGameOver;

            UpdateHealth();
        }

        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnWin += ShowWin;
        }
    }

    void Update()
    {
        if (GameManager.Instance == null)
        return;
        if (taskText != null)
        {
        if(!GameManager.Instance.hasTorch)
        {
            taskText.text = "Find the torch";
        }
        else if(!GameManager.Instance.hasFireSuit)
        {
            taskText.text = "Find the Fire Suit";
        }
        else if(!GameManager.Instance.hasChip)
        {
            taskText.text = " Find the Chip";
        }
        else if(!GameManager.Instance.hasBrokenChip)
        {
            taskText.text = "Find the Chip first to replace";
        }
        else
        {
            taskText.text = "You Win";
        }
    }
}

    public void UpdateText(string message)
    {
        if (promptText != null)
        promptText.text = message;
    }

    void UpdateHealth()
    {
        if (healthText != null && playerHealth != null)
        {
            healthText.text = "Health: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
        } 
    }

    void ShowWin()
    {
        if (winPanel != null)
        winPanel.SetActive(true);
    }

    void ShowGameOver()
    {
        if(gameOverPanel != null)
        gameOverPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -=UpdateHealth;
            playerHealth.OnDie -= ShowGameOver;
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnWin -= ShowWin;
        }
    }
}

