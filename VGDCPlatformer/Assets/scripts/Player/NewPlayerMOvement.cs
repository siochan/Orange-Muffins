using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMOvement : MonoBehaviour {


    private Rigidbody2D rb;

    private ContactPoint2D[] contacts = new ContactPoint2D[5];
    private ContactPoint2D CurrentCollider;
	public Vector2 perp;
	public float speed;
	public float grav;
	public float falling;
	public bool grounded;
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
		grav= Physics2D.gravity.y;

    }
	
	
	void Update()
	{
		//if(rb.GetContacts)
	}

	void FixedUpdate()
	{	
		if(rb.GetContacts(contacts)>1)
		{
			Debug.Log("time");
		}

		grounded = rb.GetContacts(contacts) != 0 ? true:false;
        perp = new Vector2(contacts[0].normal.y, contacts[0].normal.x);

        if(grounded){
			Physics2D.gravity= new Vector2(0f,0f);
        	rb.position += new Vector2(perp.x * Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime, perp.y * -Input.GetAxisRaw("Horizontal")*speed* Time.deltaTime);
		}
		else{
            Physics2D.gravity = new Vector2(0f, grav);

            rb.position += new Vector2( Input.GetAxisRaw("Horizontal")*speed*Time.deltaTime,falling*Time.deltaTime);
		}

	
			Debug.Log(Physics2D.gravity);
		

	}


/*	public bool groundedState()
	{
		grounded = rb.GetContacts(contacts) != 0 ? true : false;

		if(!grounded)
			return false;
        Vector2 perp = new Vector2(contacts[0].normal.y, contacts[0].normal.x);
		float angle = Mathf.Rad2Deg * Mathf.Acos(perp.y / 1f);

		if(<=angle)
	}
*/

}
