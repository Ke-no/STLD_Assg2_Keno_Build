using UnityEngine;

public class LockDoor : Interactable
{
    public enum DoorType
    {
        TorchDoor,
        FireSuitDoor
    }

    public DoorType doorType;

    protected override void Interact()
    {
        if(doorType == DoorType.TorchDoor)
        {
            if(!GameManager.Instance.hasTorch)
            {
                Debug.Log("Torch is required.");
                return;
            }
        }

        if(doorType == DoorType.FireSuitDoor)
        {
            if(!GameManager.Instance.hasFireSuit)
            {
                Debug.Log("Fire suit is required.");
                return;
            }
        }
        Destroy(gameObject);
    }
}
