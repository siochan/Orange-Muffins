﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBeginner : MonoBehaviour {

    public Rigidbody2D m_RigidBody2D;

    [Header("Movement Logic")]
    //=========== Moving Logic ============
    public float runSpeed = 0f;
    private float horizontalMove = 0f;
    private Vector3 m_Velocity;

    [Space]
    [Header("Jump Logic")]

    //============ Jump Logic ============
    public float m_JumpForce = 200f;
    private bool m_Grounded;
    public Transform m_GroundCheck;
    public LayerMask m_GroundLayer;


    // Use this for initialization
    void Start()
    {
        //m_RigidBody2D = GetComponent<Rigidbody2D>(); //Instead of manually putting the RigidBody2D Component we can get the component from the Object

        m_Velocity = Vector3.zero; //same as new Vector3(0,0,0)
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (m_Grounded && Input.GetButtonDown("Jump"))
        {
            m_Grounded = false;
            m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
        }
    }

    // FixedUpdate is called multiple times per frame at different rates
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;

        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
