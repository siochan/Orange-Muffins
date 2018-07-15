using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnemy : MonoBehaviour {

	// Use this for initialization

	public bool movRight = false; //checks if the enemy moves right or left
	public float movSpeed = 2.5f; //movement of the enemy
	

    public Transform positionA;
    public Transform positionB;

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
		if (transform.position.x >= positionA.position.x) 
		{
			Flip();
			//movRight = false;
		}
		
		//enemy moves right until reaching rightboundary
		if (transform.position.x < positionB.position.x)
		{
			Flip();
			//movRight = true;
		}
	}

	public void Die()
	{
		//object will destroy itself
		Destroy(gameObject);
	}

	void Flip()
    {
        movRight = !movRight;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
