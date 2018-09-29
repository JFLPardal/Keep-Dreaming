using System;
using UnityEngine;

public class PJMovement : MonoBehaviour {

    [SerializeField] float maxSpeed = 5;

    private SlingshotManager slingshot;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slingshot = GetComponent<SlingshotManager>();
    }

    public void AttemptMove(Vector2 movementDirection)
    {
        if(!slingshot.IsHoldingSlingshot())
        {
            Move(movementDirection);
        }
    }

    private void Move(Vector2 movementDirection)
    {
        rb.velocity = movementDirection.normalized * maxSpeed;
    }

    internal void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
