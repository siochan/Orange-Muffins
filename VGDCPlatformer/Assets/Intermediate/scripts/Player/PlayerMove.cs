using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    [SerializeField] public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;

    [Header("Pickup HUD")]
    public Text countText;
    private int count;

    [Header("Shoot Logic")]
    // Shooting Logic
    public GameObject rightPellet;
    public GameObject leftPellet;
    public Transform firePos;
    public float fireRate = 0.5f;
    private float nextFire = 0;

    void Start()
    {
        count = 0;
        SetCountText();
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
            ++count;
            SetCountText();
        }
    }

    //This function updates the text displaying the number of objects we've collected
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        countText.text = "Muffins: " + count.ToString();
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
