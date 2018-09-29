using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private SlingshotManager slingshot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        slingshot = collision.gameObject.GetComponent<SlingshotManager>();
        
        if (slingshot != null)
        {
            slingshot.AttemptItemPickup(this);
        }
    }
}
