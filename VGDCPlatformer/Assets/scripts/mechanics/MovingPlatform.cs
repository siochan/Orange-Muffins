using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    [Header("Platform Positions")]
    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;

    [Space]

    [Header("Platform Attributes")]
    public string state;
    public float platformVelocity;
    public float movementTime;

    void Start()
    {
        ChangeTarget();
    }

    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, platformVelocity * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (state == "Move1")
        {
            state = "Move2";
            newPosition = position2.position;
        }
        else if (state == "Move2")
        {
            state = "Move1";
            newPosition = position1.position;
        }
        else if (state == "")
        {
            state = "Move2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", movementTime);
    }
}
