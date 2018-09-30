using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventsTrigger : MonoBehaviour {

    [SerializeField] SpriteRenderer blackScreenBorder, cutsceneWindows;

    private bool animationEnded;

  public void EndInitialAnimation()
  {
    transform.parent.GetComponent<SceneManager>().EndInitialScene();
  }

  public void EndMainSceneFadeOut()
    {
        transform.parent.GetComponent<SceneManager>().SetRoom();
        HideCutscene();
    }

    private void HideCutscene()
    {
        Color transparent = new Color(1, 0, 1, 0);

        blackScreenBorder.color = transparent;
        cutsceneWindows.color = transparent;
    }


}
