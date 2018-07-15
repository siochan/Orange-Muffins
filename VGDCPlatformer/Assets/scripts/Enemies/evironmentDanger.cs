using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evironmentDanger : MonoBehaviour {

	public GameObject player; //in editor, put player object here for detection

	private Rigidbody2D body; //store bodytype in here

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.bodyType = RigidbodyType2D.Kinematic;
	}
	
	// If the environment makes contact with something
	void OnCollisionEnter2D(Collision2D collide)
	{
		//if environment makes contact with player, they take damage
		//Destroy environment object afterwards
		if (collide.gameObject.tag == "Player")
		{
			collide.gameObject.GetComponent<PlayerHealth>().health -= 1;
			Destroy(gameObject);
		}

		//Contact with floor will destroy environment object 
		if (collide.gameObject.tag == "floor")
		{
			Destroy(gameObject);
		}
	}

	public void playerTrigger()
	{
		//gives the environment object gravity to
		body.bodyType = RigidbodyType2D.Dynamic;
	}

	// Update is called once per frame
	void Update () {
		//environment will check (below at the moment) and move when detecting player

		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 20);
		
		if(hit.collider.gameObject.CompareTag("Player")){
			body.bodyType = RigidbodyType2D.Dynamic;	

		}
		

	
	}

	
}
