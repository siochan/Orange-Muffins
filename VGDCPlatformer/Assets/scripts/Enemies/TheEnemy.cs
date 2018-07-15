using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	// Use this for initialization

	public bool movRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	

    public Transform positionA; //gameObject that holds the left boundary
    public Transform positionB; //gameObject that holds the right boundary

    void Start () {
		
	}

	
	// Update is called once per frame
	// specifically we update movement on game object
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

		//enemy moves until reaching a boundary (whether left or right)
		//then we will flip the gameObject
		if (transform.position.x >= positionA.position.x ||
		transform.position.x < positionB.position.x) 
		{
			Flip();
		}
	}

	public void Die()
	{
		//object will destroy itself
		Destroy(gameObject);
	}

	void Flip()
    {
		//flips the entire gameObject (collider, sprite, etc.)
        movRight = !movRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1; //flips object using transform on x position
        transform.localScale = localScale;
    }
}
