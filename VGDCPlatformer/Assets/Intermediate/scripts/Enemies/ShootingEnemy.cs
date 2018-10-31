using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public float speed = 10;
    public float stoppingDistance = 20;
    public float retreatDistance = 10;

    private float timeBtShots;
    private float startTimeBtShots;

    public Transform FirePoint;
    public GameObject projectile;
    private Transform player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtShots = startTimeBtShots;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Vector2.Distance (transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); // enemy closes in
        
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
            transform.position = this.transform.position; // enemy does not move
        
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); // enemy retreats
        }
        */
        if (timeBtShots <= 0){
            Instantiate(projectile, FirePoint.position, Quaternion.identity); //spawns projectile
            timeBtShots = startTimeBtShots;
        
        } else {
            timeBtShots -= Time.deltaTime;
        }
    }
}
