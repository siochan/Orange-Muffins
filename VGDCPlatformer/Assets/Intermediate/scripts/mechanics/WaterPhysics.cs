using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour
{
    public float WaterRejectX;
    public float WaterRejectY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            CharacterController2D cc = collision.gameObject.GetComponent<CharacterController2D>();

            rb.velocity = new Vector2(rb.velocity.x - WaterRejectX, WaterRejectY);
        }
    }
}