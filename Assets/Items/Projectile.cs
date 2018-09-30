using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float throwStrength;
    [Header("RigidbodyValues")]
    [SerializeField] float linearDrag;
    [SerializeField] float angularDrag;
    [SerializeField] float hitDurationWindow = 1.5f;
    [SerializeField] float cooldownCatchTime = 1.5f;

    private Collider2D catchCollider;
    private bool canDamage = false;
    private bool canCatchThisItemAgain = true;

    public bool CanCatchItem()
    {
        return canCatchThisItemAgain;
    }

    public void Fire(Vector2 shotDirection)
    {
        transform.position += new Vector3(shotDirection.x, shotDirection.y, 0);
        GetComponent<Rigidbody2D>().velocity = shotDirection * throwStrength;
        canCatchThisItemAgain = false;
        Invoke("CanCatchThisProjectileAgain", cooldownCatchTime);
        MakeProjectileDamageable();
    }

    private void CanCatchThisProjectileAgain()
    {
        canCatchThisItemAgain = true;
    }

    void MakeProjectileDamageable()
    {
        canDamage = true;
        Invoke("CannotDamage", hitDurationWindow);
    }

    private void CannotDamage()
    {
        canDamage = false;
    }

    public bool CanDamage()
    {
        return canDamage;
    }

    public void DeactivateItemColliders()
    {
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
        ResetItemPositionToParent();
    }

    public void InitProjectile()
    {
        SetupRigidbody();
        ActivateItemColliders();
    }

    private void ActivateItemColliders()
    {
        foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            collider.enabled = true;
        }
    }

    private void SetupRigidbody()
    {
        var projectileRigidbody = gameObject.AddComponent<Rigidbody2D>();
        projectileRigidbody.mass = 0f;
        projectileRigidbody.drag = linearDrag;
        projectileRigidbody.angularDrag = angularDrag;
        projectileRigidbody.gravityScale = 0;
    }
    
    private void ResetItemPositionToParent()
    {
        transform.position = transform.parent.position;
    }

}
