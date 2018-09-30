using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int numberOfHitsToKill = 3;
    [SerializeField] float invulnerabilityTime = .5f;
    [SerializeField] float timeToRestartGame = 2f;
    [SerializeField] float timeToRemoveEnemy = 1.5f;
    [SerializeField] ParticleSystem gotHit;

    [Header("KeepDreamin scene")]
    [SerializeField] int InitialSceneNumber = 1;

    private int numberOfHitsLeft;
    private bool canTakeDamage = true;
    private bool isPlayer;
    private Animator animator;

    const string GET_HIT_TRIGGER = "Stun";
    const string DIED_TRIGGER = "Die";

    private void Start()
    {
        numberOfHitsLeft = numberOfHitsToKill;
        CheckIfPlayerOrEnemy();

        animator = GetComponent<Animator>();
    }

    private void CheckIfPlayerOrEnemy()
    {
        isPlayer = GetComponent<PJMovement>() != null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPlayer)
        {
            AttemptDamageEnemy(collision);
        }
    }

    public void AttemptDamagePlayer()
    {
        if(canTakeDamage)
        {
            TakeDamage();
            PlayParticleEffects(); 
        }
    }

    private void PlayParticleEffects()
    {
        var particleObject = Instantiate(
               gotHit,
               transform.position,
               gotHit.transform.rotation
           );
        particleObject.transform.parent = transform;
        particleObject.GetComponent<ParticleSystem>().Play();
    }

    private void AttemptDamageEnemy(Collider2D collision)
    {
        var projectile = collision.GetComponent<Projectile>();
        if (projectile != null && projectile.CanDamage() && canTakeDamage)
        {
            animator.SetTrigger(GET_HIT_TRIGGER);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        canTakeDamage = false;
        if(CheckIfCharacterDies())
        {
            KillCharacter();
        }
        else
        {
            Invoke("LiftVulnerability", invulnerabilityTime);
        }
    }

    private bool CheckIfCharacterDies()
    {
        return --numberOfHitsLeft <= 0;
    }

    private void KillCharacter()
    {
        if(isPlayer)
        {
            Invoke("RestartGame", timeToRestartGame);
        }
        else
        {
            animator.SetTrigger(DIED_TRIGGER);
            GetComponent<Rigidbody2D>().Sleep();
            GetComponent<EnemyController>().Killed();
            Invoke("DestroyEnemy", timeToRemoveEnemy);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    private void RestartGame()
    {
        //SceneManager.LoadScene(InitialSceneNumber);
    }

    private void LiftVulnerability()
    {
        canTakeDamage = true;
    }


}
