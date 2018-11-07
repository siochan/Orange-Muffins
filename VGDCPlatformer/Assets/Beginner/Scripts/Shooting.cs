using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [Header("Shooting Logic")]
    public float fireRate = 0.5f;
    private float nextFire = 0;
    public Transform firePoint;
    public GameObject pelletLeft,pelletRight;
    private bool facingRight = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
            facingRight = !facingRight;
        else if (Input.GetAxis("Horizontal") < 0 && facingRight)
            facingRight = !facingRight;
		if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
	}

    void shoot()
    {
        if (facingRight)
            Instantiate(pelletRight, firePoint.position, firePoint.rotation);
        else
            Instantiate(pelletLeft, firePoint.position, firePoint.rotation);
    }
}
