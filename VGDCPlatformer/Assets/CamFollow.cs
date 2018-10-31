using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public Transform target;
    public float smoothedSpeed = 0.1f;
    Camera myCam;

    void Start()
    {
        myCam = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        myCam.orthographicSize = (Screen.height / 100f) / 4f;
        float interpolation = smoothedSpeed * Time.deltaTime;
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, interpolation);
        }
        //transform.LookAt(target);
    }
}