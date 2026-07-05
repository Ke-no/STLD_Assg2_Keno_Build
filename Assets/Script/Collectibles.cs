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
        if (collectibleType == CollectibleType.BrokenChip && !GameManager.Instance.hasChip)
        {
            Debug.Log("Collect the new Chip first to replace.");
            return;
        }
        GameManager.Instance.Collect(collectibleType);
        Destroy(gameObject);
    }
}