using UnityEngine;

public class StuMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 6;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 translateAmount)
    {
        rb.velocity = translateAmount.normalized * maxSpeed;
    }
}