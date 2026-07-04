using UnityEngine;

public class Collectibles : Interactable
{
    public enum CollectibleType
    {
        Torch,
        FireSuit,
        Chip,
        BrokenChip
    }

    public CollectibleType collectibleType;
    protected override void Interact()
    {
        Debug.Log("Collected: " + collectibleType);

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager not found");
            return;
        }

        GameManager.Instance.Collect(collectibleType);
        Destroy(gameObject);
    }
}