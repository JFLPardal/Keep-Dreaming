using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Sprite[] itemSprites;

    private SlingshotManager slingshot;

    void Start()
    {
        AssignSprite();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        slingshot = collision.gameObject.GetComponent<SlingshotManager>();
        
        if (slingshot != null && GetComponent<Projectile>().CanCatchItem())
        {
            slingshot.AttemptItemPickup(this);
        }
    }

    private void AssignSprite()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprites[UnityEngine.Random.Range(0, itemSprites.Length)];
    }
}
