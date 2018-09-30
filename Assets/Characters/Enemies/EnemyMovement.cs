using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float walkingVelocity = 2f;

    private Rigidbody2D rb;
    private Animator animator;

    const string X_DIRECTION = "DirX";
    const string HIT_TRIGGER = "Stun";
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    public void Pushed(Vector2 directionToPush)
    {
        rb.velocity = directionToPush;
        animator.SetTrigger(HIT_TRIGGER);
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    public void SetDestination(Vector3 destinationToSet)
    {
        Vector3 directionToWalkTo = (destinationToSet - transform.position).normalized;
        rb.velocity = walkingVelocity * directionToWalkTo;
        EnemyToFacePJBoy(directionToWalkTo.x);
    }

    private void EnemyToFacePJBoy(float directionValue) //disgusting function, but the animator state machine is having problems on this transition
    {
        if(directionValue > 0)
            GetComponent<Animator>().SetFloat(X_DIRECTION, 1);
        else

            GetComponent<Animator>().SetFloat(X_DIRECTION, 0);
    }

}
