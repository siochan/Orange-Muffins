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

	// Update is called once per frame
	void Update () {
		//environment will check (below at the moment) and move when detecting player
		RaycastHit hit;

		if (Physics.SphereCast(transform.position, 1, transform.forward, out hit, 10))
		{
			if (hit.collider.CompareTag("Player"))
			{
				body.bodyType = RigidbodyType2D.Dynamic;
			}
		}
	}
}
