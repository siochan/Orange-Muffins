using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{

    public float pelletSpeed = 2f;          // controls speed of the pellet

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(pelletSpeed, 0);     // once fired, bullet will move constant speed
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Pellet will be destroyed in two ways: 
    // 1) When it collides with another collision box and
    // 2) When it exits the view of the camera

    // Function will be called when pellet collides with another collision box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);  // conosle logs what the pellet hit

        Destroy(gameObject);

        if (collision.gameObject.tag == "hurtbox2")
        {
            // When shot at, kill the enemy
            TheEnemy enemy = collision.gameObject.GetComponentInParent<TheEnemy>();
            enemy.Die();
        }
    }

    // Function will be called when pellet leaves the current camera view
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
