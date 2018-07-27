using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMOvement : MonoBehaviour
{


    private Rigidbody2D rb;

    public Vector2 perp;
    public float speed;
    private float grav;


    public bool falling;
    public bool grounded;
    public bool jumping;



    [Header("For checking ground collisions")]
    public float groundcheckVector;
    public float TeleportCheckVector;
    public LayerMask groundLayer;

    private CircleCollider2D ColliderAttach;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        grav = Physics2D.gravity.y;
        ColliderAttach = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {

            rb.velocity = Vector2.up * 10;
            grounded = false;
            jumping = true;
        }


        if (rb.velocity.y < 0 && !grounded)
        {
            falling = true;
            jumping = false;
        }

        Debug.Log(jumping);

        if (!jumping)
            Grounding();
    }

    void FixedUpdate()
    {

        if (!grounded)
        {
            Physics2D.gravity = new Vector2(0f, grav);
        }
        else
            Physics2D.gravity = new Vector2(0f, 0f);


        float YMovement = grounded ? -Input.GetAxisRaw("Horizontal") * speed * perp.y : rb.velocity.y;
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * perp.x, YMovement);

    }

    public void Grounding()
    {
        slopeCheck();
        // RaycastHit2D FowardGroundCast = Physics2D.Linecast(transform.position+new Vector3(.5f,0,0), transform.position - new Vector3(-.5f, groundcheckVector, 0), groundLayer);
        // RaycastHit2D BackGroundCast = Physics2D.Linecast(transform.position-new Vector3(.5f, 0,0), transform.position - new Vector3(.5f, groundcheckVector, 0), groundLayer);

        // if (FowardGroundCast||BackGroundCast)
        // {

        //     grounded = true;
        //     falling = false;

        // }
        // else
        // {
        //     grounded = false;         
        // }

        // Color color = grounded ? Color.green : Color.red;
        // if (FowardGroundCast)
        //     perp = new Vector2(FowardGroundCast.normal.y, FowardGroundCast.normal.x);
        // else if (BackGroundCast)
        //     perp = new Vector2(BackGroundCast.normal.y, BackGroundCast.normal.x);


        //  Debug.DrawLine(transform.position + new Vector3(.5f, 0, 0), transform.position - new Vector3(-.5f, groundcheckVector, 0), color);
        //  Debug.DrawLine(transform.position - new Vector3(.5f, 0, 0), transform.position - new Vector3(.5f, groundcheckVector, 0), color);
        // teleport down check
        Vector2 boxCastOrigin = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal"), transform.position.y);
        //   Debug.DrawRay(boxCastOrigin, Vector3.down, Color.blue);
        if (!grounded && !jumping && !falling)
        {

            RaycastHit2D SlopeleavingCast = Physics2D.BoxCast(boxCastOrigin, new Vector2(ColliderAttach.radius * 2, ColliderAttach.radius * 2), 0f, Vector2.down, TeleportCheckVector, groundLayer);
            //   Debug.Log(SlopeleavingCast.distance + " distance");

            if (SlopeleavingCast)
            {
                rb.position += new Vector2(0, -SlopeleavingCast.distance);
                grounded = true;
            }
            else
            {
                if (!falling)
                {
                    grounded = false;
                    falling = true;
                    rb.velocity = new Vector2(0f, 0f);
                }

            }


            Color color2 = SlopeleavingCast ? Color.green : Color.red;
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, TeleportCheckVector, 0), color2);


        }
        // Debug.Log(rb.velocity);


    }

    private void slopeCheck()
    {
        RaycastHit2D FowardGroundCast = Physics2D.Linecast(transform.position + new Vector3(.5f, 0, 0), transform.position - new Vector3(-.5f, groundcheckVector, 0), groundLayer);
        RaycastHit2D BackGroundCast = Physics2D.Linecast(transform.position - new Vector3(.5f, 0, 0), transform.position - new Vector3(.5f, groundcheckVector, 0), groundLayer);

        if (FowardGroundCast || BackGroundCast)
        {

            grounded = true;
            falling = false;

        }
        else
        {
            grounded = false;
        }

        Color color = grounded ? Color.green : Color.red;
        if (FowardGroundCast)
            perp = new Vector2(FowardGroundCast.normal.y, FowardGroundCast.normal.x);
        else if (BackGroundCast)
            perp = new Vector2(BackGroundCast.normal.y, BackGroundCast.normal.x);


        float angle = Mathf.Rad2Deg * Mathf.Acos(perp.x / 1);
        Debug.Log(angle);

        Debug.DrawLine(transform.position + new Vector3(.5f, 0, 0), transform.position - new Vector3(-.5f, groundcheckVector, 0), color);
        Debug.DrawLine(transform.position - new Vector3(.5f, 0, 0), transform.position - new Vector3(.5f, groundcheckVector, 0), color);


    }

}
