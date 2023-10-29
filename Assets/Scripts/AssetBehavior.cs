using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBehavior : MonoBehaviour
{
    public BEHAVIORS behavior;
    public INTERACTIONTYPE type;
    [Header("Move Behavior Variables")]
    public float maxSpeed;
    private float speed = 0f;
    [HideInInspector]
    private Transform mTransform;
    public bool isFree;
    public bool isActive;
    
    void Start()
    {
        mTransform = transform;
        speed = Random.Range(1, maxSpeed);
    }

    void Update()
    {
        switch (behavior)
        {
            case BEHAVIORS.MOVE:
                if(GameManager.instance.gameMode != GAMEMODE.IDLE)
                {
                    mTransform.position = new Vector3(speed * Time.deltaTime + mTransform.position.x, mTransform.position.y, mTransform.position.z);
                }
                break;
        }
    }

    public void Show(Transform targetPosition)
    {
        isActive = true;
        isFree = false;
        mTransform.position = targetPosition.position;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        isActive = false;
        isFree = true;
        gameObject.SetActive(false);
    }
}
