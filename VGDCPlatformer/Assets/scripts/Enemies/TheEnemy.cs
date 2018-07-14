using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	// Use this for initialization

	public bool movRight = true; //checks if the enemy moves right or left
	public float movSpeed = 1f; //movement of the enemy
	public float rightBound = 16.0f; //how far to the right to go
	public float leftBound = 8.0f; //how far to the left to go

	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if (movRight)
		{
			transform.Translate(Vector2.right * movSpeed * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector2.left * movSpeed * Time.deltaTime);
		}

		if (transform.position.x >= rightBound)
		{
			movRight = false;
		}
		
		if (transform.position.x < leftBound)
		{
			movRight = true;
		}
	}
}
