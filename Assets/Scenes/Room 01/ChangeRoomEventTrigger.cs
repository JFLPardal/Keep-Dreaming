using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomEventTrigger : MonoBehaviour {

    [SerializeField] EnemyLoader enemyLoader;

  private GameObject SM;

  void Start()
  {
    SM = transform.parent.parent.gameObject;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if(collider.GetComponent<PJMovement>() != null && EnemyLoader.isRoomClear && !enemyLoader.IsLastRoom())
        {
            SM.GetComponent<SceneManager>().ChangeRoom();
            enemyLoader.PlayerEnteredNewRoom();
        }
    }
}
