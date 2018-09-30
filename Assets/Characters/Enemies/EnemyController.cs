using System.Collections;
using UnityEngine;

enum EnemyState { idle, attacking, chasing, beingPushed, dead, onTimeout };

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class EnemyController : MonoBehaviour
{
    enum TypeOfEnemy { spider, snake};

    const string BOOL_IS_WALKING = "isWalking";

    [SerializeField] private float chaseRadius = 3;
    [SerializeField] private float timeoutAfterAttack = 1.5f;
    [SerializeField] private float attackRadius = 1;
    [SerializeField] private float pushDuration = 1;
    [SerializeField] private TypeOfEnemy type;

    private EnemyState currentState;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private PJMovement pjBoy;
    private Animator animator;
    
    void Start()
    {
        currentState = EnemyState.idle;
        GetEnemyComponents();
    }

    void Update()
    {
        float distanceToPJBoy = Vector2.Distance(transform.position, pjBoy.transform.position);
        bool playerIsOutsideChaseRadius = distanceToPJBoy > chaseRadius; // THIS ASSUMES CHASE RADIUS IS THE LARGEST RADIUS
        bool playerIsInChaseRadius = distanceToPJBoy < chaseRadius && distanceToPJBoy > attackRadius ;
        bool playerIsInAttackRadius = distanceToPJBoy < attackRadius;
        
        if(currentState != EnemyState.dead)
        {
            if (currentState != EnemyState.beingPushed)
            {
                if (currentState != EnemyState.onTimeout)
                {
                    if (currentState != EnemyState.idle && playerIsOutsideChaseRadius)
                    {
                        StopAllCoroutines();
                        Idle();
                    }
                    if (playerIsInAttackRadius)
                    {
                        StopAllCoroutines();
                        AttackPlayer();
                    }
                    if (currentState != EnemyState.chasing && playerIsInChaseRadius)
                    {
                        StopAllCoroutines();
                        StartCoroutine(ChasePlayer());
                    }
                }
                else
                {
                    StopMovement();
                }
            }
            else
            {
                StopAllCoroutines();
            }
        }
        else
        {
            StopMovement();
        }
    }

    private void AttackPlayer()
    {
        currentState = EnemyState.attacking;
        attack.AttackTarget(pjBoy.gameObject);
        StopMovement();
        currentState = EnemyState.onTimeout;
        Invoke("LiftTimeout", timeoutAfterAttack);
    }

    private void LiftTimeout()
    {
        currentState = EnemyState.idle;
    }

    private void Idle()
    {
        currentState = EnemyState.idle;
        animator.SetBool(BOOL_IS_WALKING, false);
        StopMovement();
    }

    IEnumerator ChasePlayer()
    {
        currentState = EnemyState.chasing;
        animator.SetBool(BOOL_IS_WALKING, true);
        while(Vector2.Distance(transform.position, pjBoy.transform.position) > attackRadius)
        {
            movement.SetDestination(pjBoy.transform.position);
            yield return new WaitForEndOfFrame();
        }
    }

    public void BeingPushed(float pushMagnitude, Vector2 directionOfPush)
    {
        currentState = EnemyState.beingPushed;
        movement.Pushed(directionOfPush * pushMagnitude);
        Invoke("StopPush", pushDuration);
    }

    public void Killed()
    {
        StopAllCoroutines();
        StopMovement();
        currentState = EnemyState.dead;
        GameObject.FindObjectOfType<EnemyLoader>().EnemyDied();
    }

    private void GetEnemyComponents()
    {
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        pjBoy = GameObject.FindObjectOfType<PJMovement>();
        animator = GetComponent<Animator>();
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);    
    }*/

    private void StopMovement()
    {
        movement.StopMovement();
    }

    private void StopPush()
    {
        currentState = EnemyState.idle;
        StopMovement();
    }
}
