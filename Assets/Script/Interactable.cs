using UnityEngine;

/*
*Author: Keno
*Date: 10/6/2026
*Description: Base code for all objects that can be interacted with key E
*/

public abstract class Interactable : MonoBehaviour
{
    /*message displays to player when looking at an interactable*/
    public string promptMessage;

    /*this function will be called by PlayerInteract*/
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        /*template function to be overridden by subclassess*/
    }
}

/*Inherited: Collectibles, Keypad, Remote*/