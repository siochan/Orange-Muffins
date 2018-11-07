using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float speed;

    private float timeBtShots;
    public float startTimeBtShots;

    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtShots = startTimeBtShots;
    }

    void Update()
    {

        if (timeBtShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtShots = startTimeBtShots;

        }
        else
        {
            timeBtShots -= Time.deltaTime;
        }

    }


}
