﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 1; //the amount of health the player is suppose to start with
	public int health; //the amount of health the player has, at 0 player dies

    private GameObject gameManager;
    private LevelManager levelManager;

	//public float playerSpawnX = -17.3f; //where the player spawns at start or death, X coord
	//public float playerSpawnY = -1.9f; //where the player spawns at start or death, Y coord

    public Transform SpawnPoint;

    //public Vector2 respawnPoint;

	//Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
        levelManager = gameManager.GetComponent<LevelManager>();

		health = startHealth;

        //respawnPoint = transform.position;

        GameManager.UpdateSpawn(SpawnPoint);
        gameObject.transform.position = GameManager.spawnPoint.position;
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

        if(collide.gameObject.tag == "checkPoint")
        {
            SpawnPoint = collide.transform;
            GameManager.UpdateSpawn(collide.transform);

            //respawnPoint = collide.transform.position;
        }
	}

	// Update is called once per frame
	void Update () {
		//player dies here
		if (health <= 0)
		{
            gameObject.SetActive(false);    // kills player
        }
	}

	public void TakeDamage(){
		health--;
	}
}
