using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class HangingBall : IChangeableObject
{
    HingeJoint2D hingeToBall;

    private void Start()
    {
        hingeToBall = GetComponent<HingeJoint2D>(); 
    }
    public override void SetActiveDimension()
    {
        Debug.Log("Active");

        gameObject.layer = (int)Layers.activeDimensionLayer;
    }

    public override void SetAlternateDimension()
    {
        Debug.Log("Alternate");
        gameObject.layer = (int)Layers.alternateDimensionLayer;
        Destroy(hingeToBall);
    }
}

