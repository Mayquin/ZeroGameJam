using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Transform endPoint;
    [HideInInspector]
    public bool isActive = false;
    [HideInInspector]
    public bool isFree = false;
    [HideInInspector]
    public Transform mTransform = null;


    public Environment Hide()
    {
        gameObject.SetActive(false);
        isFree = true;
        isActive = false;
        return this;
    }

    public Environment Show(Transform targetPosition)
    {
        if(mTransform == null) mTransform = transform;
        mTransform.position = targetPosition.position;
        gameObject.SetActive(true);
        isFree = false;
        isActive = true;
        return this;
    }

    public void SetupEnvironment()
    {
        // Spawn pumpkins and etc
    }
}
