using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{

    public float speed;

    public Transform target;
    private Vector2 direction;

    void Start()
    {

        //target = GameObject.FindGameObjectWithTag("Player").transform;

        direction = new Vector2(target.position.x, target.position.y);
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);

        /*
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        */
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();

        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    */

    void OnCollisionEnter(){
        Destroy(gameObject);
    }
/*   
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
*/    
}