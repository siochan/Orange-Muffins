using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "hurtbox")
        {
            //to kill enemy, we tell the enemy script
            TheEnemy script = collision.gameObject.GetComponentInParent<TheEnemy>();
            script.Die();
        }
    }
}
