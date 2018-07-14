using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 1; //the amount of health the player has, at 0 player dies
	public float spawnX = -17.3f; //where the player spawns at start or death, X coord
	public float spawnY = -1.9f; //where the player spawns at start or death, Y coord
	// Use this for initialization
	void Start () {
		
	}
	
	//will occur when player interacts with Enemy object
	void OnCollisionEnter2D (Collision2D collide)
	{
		if (collide.gameObject.tag == "hurtbox")
		{
			Debug.Log("NICE!");
			Destroy(collide.gameObject); //destroy the enemy object
		}

		if (collide.gameObject.tag == "slimeHitBox")
		{
			health--; //player takes damage
			Debug.Log("OH NO!");
			//player dies here
			if (health <= 0)
			{
				transform.position = new Vector3(spawnX, spawnY, transform.position.z);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
