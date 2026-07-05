using UnityEngine;

public class LockDoor : Interactable
{
    public enum DoorType
    {
        TorchDoor,

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
        Destroy(gameObject);
    }
}
