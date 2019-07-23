using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlobTransparency : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Coroutine transparencyCoroutine;

    public float changeRate = 1f;
    public float setTransparentRate = 1f;
    public float updateInterval = 0.06f;

    public bool isTransparent;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTransparency(!isTransparent);
        }
    }

    public void SetTransparency(bool setTransparent)
    {
        if (isTransparent == setTransparent)
            return;

        isTransparent = setTransparent;

        if (transparencyCoroutine != null)
            StopCoroutine(transparencyCoroutine);
        transparencyCoroutine = StartCoroutine(LerpTransparency(!isTransparent));

    }

    public IEnumerator LerpTransparency(bool setTransparency)
    {

        Color targetColor = Color.white;
        if (setTransparency)
            targetColor.a = 0;

        while (Mathf.Abs(spriteRenderer.color.a - targetColor.a) > 0.03)
        {
            float num = setTransparency ? setTransparentRate : 1;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, changeRate / updateInterval / num);
            Debug.Log(spriteRenderer.color.a);
            yield return new WaitForSeconds(updateInterval);
        }

        spriteRenderer.color = targetColor;
    }
    private void OnRenderObject()
    {
        
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //but source texture into 
    }
}

//camera for the blob layer
//render texture stores this data
//this data is used by fragment? shader. Get object position, texture data