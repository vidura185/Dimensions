using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraImageEffect : MonoBehaviour
{
    public Material mat;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debug.Log("Render");
        Graphics.Blit(source, destination,mat);
    }
}
