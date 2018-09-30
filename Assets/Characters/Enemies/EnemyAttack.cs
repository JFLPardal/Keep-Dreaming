using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    const string ATTACK_TRIGGER = "Attack";

	public void AttackTarget(GameObject targetToAttack)
    {
        if(targetToAttack.GetComponent<PJMovement>() != null)
        {
            targetToAttack.GetComponent<HealthSystem>().AttemptDamagePlayer();
            GetComponent<Animator>().SetTrigger(ATTACK_TRIGGER);
        }
    }
}
