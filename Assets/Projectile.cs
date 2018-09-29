using UnityEngine;

public class Projectile : MonoBehaviour {


	public void Fire(Vector2 shotDirection)
    {
        GetComponent<Rigidbody2D>().velocity = shotDirection;
    }
}
