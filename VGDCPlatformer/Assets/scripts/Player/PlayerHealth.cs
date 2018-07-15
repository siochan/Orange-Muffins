using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 1; //the amount of health the player has, at 0 player dies
	public float playerSpawnX = -17.3f; //where the player spawns at start or death, X coord
	public float playerSpawnY = -1.9f; //where the player spawns at start or death, Y coord

	// Use this for initialization
	void Start () {
		
	}
	
	
	//will occur when player interacts with Enemy object
	void OnTriggerEnter2D (Collider2D collide)
	{
		if (collide.gameObject.tag == "hurtbox")
		{
			//to kill enemy, we tell the enemy script
			TheEnemy script = collide.gameObject.GetComponentInParent<TheEnemy>();
			script.Die();
		}

		if (collide.gameObject.tag == "hitbox")
		{
			health--; //player takes damage
		}
	}

	// Update is called once per frame
	void Update () {
		//player dies here
		if (health <= 0)
		{
			//respawn player to beginning
			transform.position = new Vector3(playerSpawnX, 
			playerSpawnY, transform.position.z);
		}
	}
}
