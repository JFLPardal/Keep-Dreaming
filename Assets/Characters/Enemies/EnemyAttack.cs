using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public void AttackTarget(GameObject targetToAttack)
    {
        if(targetToAttack.GetComponent<PJMovement>() != null)
        {
            print("attack " + targetToAttack.name);
        }
    }
}
