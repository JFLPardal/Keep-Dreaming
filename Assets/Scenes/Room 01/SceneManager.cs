using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameObject mainSceneDisplay;
    private GameObject cutSceneDisplay;
    [SerializeField] private Sprite[] mainScene;
    private int currentRoom;

    // Use this for initialization
    void Start ()
    {
        currentRoom = 0;
        mainSceneDisplay = transform.GetChild(0).gameObject;
        cutSceneDisplay = transform.GetChild(1).gameObject;
    }
	

    public void EndInitialScene()
    {
        mainSceneDisplay.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void ChangeRoom()
    {
        currentRoom++;
        mainSceneDisplay.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void SetRoom()
    {
        mainSceneDisplay.GetComponent<SpriteRenderer>().sprite = mainScene[currentRoom];
        mainSceneDisplay.GetComponent<Animator>().SetTrigger("FadeIn");
    }
}
