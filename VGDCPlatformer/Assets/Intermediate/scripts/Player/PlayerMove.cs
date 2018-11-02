using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;

    [Header("Shoot Logic")]
    // Shooting Logic
    public GameObject rightPellet;
    public GameObject leftPellet;
    public Transform firePos;
    public float fireRate = 0.5f;
    private float nextFire = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
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

    void fire()
    {
        if(controller.m_FacingRight)
        {
            Instantiate(rightPellet, firePos.position, Quaternion.identity);
        }
        else if(!controller.m_FacingRight)
        {
            Instantiate(leftPellet, firePos.position, Quaternion.identity);
        }
    }
}
