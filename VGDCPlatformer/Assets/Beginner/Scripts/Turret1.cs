using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : MonoBehaviour
{

    public float speed; 

    private float timeBtShots;
    public float startTimeBtShots;
    public GameObject projectile;

    public float delay;
    public int shootDelayRatio;

    void Start()
    {
        timeBtShots = startTimeBtShots;
    }

    void Update()
    {
        //Debug.Log("time = " + Time.time + " delay = " + delay);
        if ( (int)(Time.time/delay) % shootDelayRatio != 1)
        {
            if (timeBtShots <= 0)
            {
                //Instantiate(projectile, transform.position, Quaternion.identity);
                Instantiate(projectile, transform.position, transform.rotation);
                timeBtShots = startTimeBtShots;
            }
            else
            {
                timeBtShots -= Time.deltaTime;
            }
        }

    }


}