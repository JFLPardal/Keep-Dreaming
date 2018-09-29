using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var projectile = collision.GetComponent<Projectile>();
        if(projectile!= null && projectile.CanDamage())
        {
            print("item hit");
        }
    }
}
