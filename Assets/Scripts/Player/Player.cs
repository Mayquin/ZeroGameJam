using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float mAngle = 45f;
    public float powerFactor = 25f;

    private Vector2 mInitialPosition;
    private Vector2 mInitialVelocity;
    private float mTime;
    private Transform mTransform;
    public Transform footTransform;
    public float collisionRadius;
    public LayerMask collisionLayers;
    public bool hitOtherColider;

    private float CalculateNewPosition(float acceleration, float velocity, float position, float time)
    {
        return .5f * acceleration * time * time + velocity * time + position;
    }

    public void Launch(float power)
    {
        mInitialVelocity = new Vector2(Mathf.Cos(mAngle * Mathf.PI / 180), Mathf.Sin(mAngle * Mathf.PI / 180)) * power * powerFactor;
        mInitialPosition = new Vector2(mTransform.position.x, mTransform.position.y);
    }
    void Start()
    {
        mTransform = GetComponent<Transform>();
        GameManager.instance.player = this;
    }

    void Update()
    {
        if (GameManager.instance.gameMode == GAMEMODE.LAUNCHED)
        {
            mTime += Time.deltaTime;
            float newPositionX = CalculateNewPosition(0, mInitialVelocity.x, mInitialPosition.x, mTime);
            float newPositionY = CalculateNewPosition(-9.8f, mInitialVelocity.y, mInitialPosition.y, mTime);
            mTransform.position = new Vector3(newPositionX, newPositionY, mTransform.position.z);

            CheckCollision();
        }
    }

    void CheckCollision()
    {
        var colliders = Physics.OverlapSphere(footTransform.position, collisionRadius, collisionLayers);
        
        foreach (var collider in colliders)
        {
            switch(collider.gameObject.layer)
            {
                case ((int)LAYERS.GOODPUMPKIN):
                    mInitialVelocity = new Vector2(Mathf.Cos(mAngle * Mathf.PI / 180), Mathf.Sin(mAngle * Mathf.PI / 180)) * powerFactor;
                    mInitialPosition = new Vector2(mTransform.position.x, mTransform.position.y);
                    mTime = 0;
                    collider.gameObject.SetActive(false);
                    break;
                case ((int)LAYERS.BADPUMPKIN):
                    mInitialVelocity = new Vector2(Mathf.Cos(mAngle * Mathf.PI / 180), Mathf.Sin(mAngle * Mathf.PI / 180)) * mInitialVelocity/2;
                    mTime = 0;
                    break;
                case ((int)LAYERS.GROUND):
                    mInitialVelocity = Vector2.zero;
                    mInitialPosition= Vector2.zero;
                    break;
            }

            Debug.Log("Is hitting something");
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(footTransform.position, collisionRadius);
    }
}
