using System;
using UnityEngine;

public class SlingshotManager : MonoBehaviour {

    private bool isHoldingItem = false;
    private bool isHoldingSlingshot = false;
    private ItemPickup ItemHeld;

	public bool IsHoldingItem()
    {
        return isHoldingItem;
    }

    public bool IsHoldingSlingshot()
    {
        return isHoldingSlingshot;
    }

    public void AttemptItemPickup(ItemPickup itemToHold)
    {
        if (!isHoldingItem)
        {
            HoldItem(itemToHold);
        }
    }

    private void HoldItem(ItemPickup itemToHold)
    {
        isHoldingItem = true;
        ItemHeld = itemToHold;
        DeactivateItemColliders();
        itemToHold.gameObject.transform.parent = this.gameObject.transform;
    }

    private void DeactivateItemColliders()
    {
        foreach (Collider2D collider in ItemHeld.GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }

    public void AttemptFireSlingshot()
    {
        if(isHoldingSlingshot && isHoldingItem)
        {
            FireSlingshot();
        }
    }

    private void FireSlingshot()
    {
        print("fire slingshot");
    }

    public void Held()
    {
        isHoldingSlingshot = true;
        print("holding slinghsot");
    }

    public void Released()
    {
        isHoldingSlingshot = false;
        print("released slingshot");
    }
}
