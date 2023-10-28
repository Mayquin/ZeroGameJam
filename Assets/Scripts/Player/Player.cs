using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigidBody;
    private float mAngle = 45f;
    public float power = 20f;

    private Vector2 mInitialPosition;
    private Vector2 mInitialVelocity;
    private float mTime;
    private bool mIsLaunched;
    private Transform mTransform;

    private float CalculateNewPosition(float acceleration, float velocity, float position, float time)
    {
        return .5f * acceleration * time * time + velocity * time + position;
    }

    private void Launch()
    {
        mInitialVelocity = new Vector2(Mathf.Cos(mAngle * Mathf.PI / 180), Mathf.Sin(mAngle * Mathf.PI / 180)) * power;
        mInitialPosition = new Vector2(mTransform.position.x, mTransform.position.y);
        mIsLaunched = true;

    }
    void Start()
    {
        mTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if(mIsLaunched)
        {
            mTime = Time.deltaTime;
            float newPositionX = CalculateNewPosition(0, mInitialVelocity.x, mInitialPosition.x, mTime);
            float newPositionY = CalculateNewPosition(-9.8f, mInitialVelocity.x, mInitialPosition.x, mTime);
            mTransform.position = new Vector3(newPositionX, newPositionY, mTransform.position.z);
        }
    }
}
