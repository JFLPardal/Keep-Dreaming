using System;
using System.Collections;
using UnityEngine;

enum EnemyState { idle, attacking, chasing };

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float chaseRadius = 3;
    [SerializeField] private float attackRadius = 1;

    private EnemyState currentState;
    private EnemyMovement movement;
    private EnemyAttack attack;
    private PJMovement pjBoy;
    private StuMovement stu;
    
    void Start()
    {
        currentState = EnemyState.idle;
        GetEnemyComponents();
    }

    void Update()
    {
        float distanceToPJBoy = Vector2.Distance(transform.position, pjBoy.transform.position);
        bool playerIsInChaseRadius = distanceToPJBoy < chaseRadius && distanceToPJBoy > attackRadius;
        bool playerIsInAttackRadius = distanceToPJBoy < attackRadius;

        if (currentState != EnemyState.idle)
        {

        }
        if (currentState != EnemyState.attacking && playerIsInAttackRadius)
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

    private void AttackPlayer()
    {
        currentState = EnemyState.attacking;
        attack.AttackTarget(pjBoy.gameObject);
        
    }

    IEnumerator ChasePlayer()
    {
        currentState = EnemyState.chasing;
        while(Vector2.Distance(transform.position, pjBoy.transform.position) > attackRadius)
        {
            movement.SetDestination(pjBoy.transform.position);
            yield return new WaitForEndOfFrame();
        }
    }



    private void GetEnemyComponents()
    {
        movement = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        pjBoy = GameObject.FindObjectOfType<PJMovement>();
        stu = GameObject.FindObjectOfType<StuMovement>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);    
    }
}
