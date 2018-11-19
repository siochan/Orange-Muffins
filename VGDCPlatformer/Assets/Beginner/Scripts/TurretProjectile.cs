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
        direction = new Vector2(target.position.x, target.position.y);
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }


   //void OnCollisionEnter(){
    //void OnTriggerEnter2D(Collider2D collision)
    //{
        //Destroy(gameObject); //Destroys Projectile
    //}
/*   
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
*/    
}