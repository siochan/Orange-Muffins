using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	// Use this for initialization

	public bool movRight = true; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	public float rightBound = 16.0f; //how far to the right to go
	public float leftBound = 8.0f; //how far to the left to go

	public float enemySpawnX = 15f; //where the enemy will spawn, x coord
	public float enemySpawnY = -2f; //where the enemy will spawn, y coord

	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		//enemy will move to the right
		if (movRight)
		{
			transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
		}

		//enemy will move to the left
		else
		{
			transform.Translate(Vector2.left * movSpeed * Time.deltaTime);
		}

		//enemy moves left until reaching leftboundary
		if (transform.position.x >= rightBound) 
		{
			movRight = false;
		}
		
		//enemy moves right until reaching rightboundary
		if (transform.position.x < leftBound)
		{
			movRight = true;
		}
	}

	public void Die()
	{
		//object will destroy itself
		Destroy(gameObject);
	}
}
