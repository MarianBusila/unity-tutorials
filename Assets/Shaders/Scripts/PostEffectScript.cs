using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectScript : MonoBehaviour {
    public Material postEffectMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // apply changes to source before passing it on
        Graphics.Blit(source, destination, postEffectMaterial);
    }
}
