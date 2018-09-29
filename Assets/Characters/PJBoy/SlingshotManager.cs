using System;
using UnityEngine;

public class SlingshotManager : MonoBehaviour
{
    private bool isHoldingItem = false;
    private bool isHoldingSlingshot = false;
    private ItemPickup itemHeld;
    private Vector2 slingshotDirection = new Vector2(1,0);

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
        itemHeld = itemToHold;
        Destroy(itemHeld.GetComponent<Rigidbody2D>());
        itemToHold.gameObject.transform.parent = this.gameObject.transform;
        itemHeld.GetComponent<Projectile>().DeactivateItemColliders();
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
        itemHeld.transform.parent = null;
        isHoldingItem = false;

        itemHeld.GetComponent<Projectile>().InitProjectile();
        itemHeld.GetComponent<Projectile>().Fire(slingshotDirection);
    }

    public void Held(Vector2 pointedDirection)
    {
        isHoldingSlingshot = true;
        if(pointedDirection != Vector2.zero)
        {
            slingshotDirection = pointedDirection;
        }
        print("holding slinghsot");
    }

    public void Released()
    {
        isHoldingSlingshot = false;
        print("released slingshot");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 positionAsVector2 = new Vector2(transform.position.x, transform.position.y);
        Gizmos.DrawLine(transform.position, positionAsVector2 + slingshotDirection);
    }
}
