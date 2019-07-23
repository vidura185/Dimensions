using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeablePlatform : IChangeableObject
{
    Animator animator;
    public override void SetActiveDimension()
    {
        gameObject.layer = (int)Layers.activeDimensionLayer;
        
        foreach(BlobTransparency blobTransparency in blobTransparencies)
        {
            blobTransparency.SetTransparency(true);
        }
    }

    public override void SetAlternateDimension()
    {
        gameObject.layer = (int)Layers.alternateDimensionLayer;

        foreach (BlobTransparency blobTransparency in blobTransparencies)
        {
            blobTransparency.SetTransparency(false);
        }
    }

}

public enum AnimationStates
{
    WALKING,
    BLOCKED,
    JUMP
}