using UnityEngine;

public class PostVisualEffects : MonoBehaviour {

    [SerializeField] Material effectToApply;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectToApply);
    }
}
