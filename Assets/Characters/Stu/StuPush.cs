using UnityEngine;

public class StuPush : MonoBehaviour
{
    [SerializeField] float pushCooldownTimer = 1.5f;
    [SerializeField] float pushActivatedDuration = .5f;
    [SerializeField] float pushMagnitude = 5f;
    
    private bool canPush = true;
    private bool buttonToPushPressed = false;

    const string ATTACK_TRIGGER = "Attack";
    
    public void AttemptingToPush()
    {
        buttonToPushPressed = true;
        Invoke("SetButtonPressedToFalse", pushActivatedDuration);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>() != null && buttonToPushPressed && canPush)
        {
            PushEnemy(collision.gameObject);
        }  
    }

    private void PushEnemy(GameObject enemyPushed)
    {
        GetComponent<Animator>().SetTrigger(ATTACK_TRIGGER);
        Vector2 directionOfPush = enemyPushed.transform.position - transform.position;
        enemyPushed.GetComponent<EnemyController>().BeingPushed(pushMagnitude, directionOfPush.normalized);
        canPush = false;
        Invoke("CanPushAgain", pushCooldownTimer);
    }

    private void CanPushAgain()
    {
        canPush = true;
    }

    private void SetButtonPressedToFalse()
    {
        buttonToPushPressed = false;
    }
}
