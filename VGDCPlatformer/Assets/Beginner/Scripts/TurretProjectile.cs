using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{

    public float speed;

    public Transform target;
    private Vector2 direction;
    Vector3 projectilePosition;
    //
    //private Vector3 normalizeDirection;
    //

    void Start()
    {
        direction = new Vector2(target.position.x, target.position.y);
        Debug.Log("rotation = " + transform.rotation);
        //
        //normalizeDirection = (target.position - transform.position).normalized;
        //
        projectilePosition = transform.position;
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        //transform.Translate(Vector3.up) * speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

        //T2//transform.position += normalizeDirection * speed * Time.deltaTime;


        /* INPUT = DEGREES 
        if (transform.rotation.z == 0){
        transform.position += transform.position.y - 1;
        }
         */
        //projectilePosition.y += 1;

    }

   //void OnCollisionEnter(Collision collision)
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }   
}