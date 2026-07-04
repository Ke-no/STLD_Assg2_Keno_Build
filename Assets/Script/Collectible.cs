using UnityEngine;

/*
*Author: Keno
*Date: 14/6/2026
*Description: Player able to interact and collect items
*/

/*increment item count*/
public class Collectibles : Interactable
{
    [SerializeField]
    private bool isEgg = false;
    protected override void Interact()
    {
/*player clicks E, collect item*/
        GameManager.Instance.CollectItem();
/*if its egg, count separately*/
        if (isEgg)
        {
            GameManager.Instance.CollectEgg();
        }
/*delete item from game*/     
        Destroy(gameObject);
    }
}
