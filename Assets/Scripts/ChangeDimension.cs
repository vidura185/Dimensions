using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ChangeDimension : MonoBehaviour
{
    public List<IChangeableObject> activeObjects;
    public BlobTransparency transparency;

    public bool isActive;
    private void Start()
    {
        transparency = GetComponentInChildren<BlobTransparency>();
        transparency.SetTransparency(false);
    }
    public void Update()
    {
        isActive = false;
        if (Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            transform.position = position;
            isActive = true;
            transparency.SetTransparency(true);
        }
        else
            transparency.SetTransparency(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        //set active
        if (isActive)
        {
            IChangeableObject changeableObject = other.GetComponent<IChangeableObject>();
            if (changeableObject)
            {
                if (!activeObjects.Contains(changeableObject))
                {
                    activeObjects.Add(changeableObject);
                    changeableObject.SetActiveDimension();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isActive)
        {
            foreach (IChangeableObject changeableObject in activeObjects)
            {
                changeableObject.SetAlternateDimension();
            }
        }
        else
        {
            IChangeableObject changeableObject = other.GetComponent<IChangeableObject>();
            if (changeableObject && activeObjects.Contains(changeableObject))
            {
                Debug.Log("IOJOIJOI" + other.gameObject.name + other.name);
                if (changeableObject)
                {
                    activeObjects.Remove(changeableObject);
                    changeableObject.SetAlternateDimension();
                }
            }
        }
    }
}

/***
* HOW?
* bool setActive
* on player collide, if set active do something special?
***/