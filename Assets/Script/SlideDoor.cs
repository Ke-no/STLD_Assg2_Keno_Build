using UnityEngine;

public class SlideDoor : Interactable
{
    public enum DoorType
    {
        FireSuitDoor
    }

    public DoorType doorType;

    [SerializeField]
    private Animator animator;

    private bool isOpen = false;

    protected override void Interact()
    {

        if (doorType == DoorType.FireSuitDoor && !GameManager.Instance.hasFireSuit)
        {
            Debug.Log("It is hot in there, are you sure you don't need a fire suit?");
            return;
        }

        isOpen = !isOpen;

        if(animator != null)
        {
            animator.SetBool("IsOpen", isOpen);
        }
    }
}

