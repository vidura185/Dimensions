using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class IChangeableObject : MonoBehaviour
{
    public BlobTransparency[] blobTransparencies;
    public abstract void SetActiveDimension();
    public abstract void SetAlternateDimension();

    public void Start()
    {
        blobTransparencies= GetComponentsInChildren<BlobTransparency>();
    }
}
