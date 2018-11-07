using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    int MinDist = 10;
    public float speed;
    private Transform enemy;
    private Transform target;
    Vector2 originalPos;
    public float range;
    //public float snailsSpeed;
    //private GameObject player;
    //public LayerMask m_GroundLayer;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        originalPos = gameObject.transform.position;
        //snailsSpeed = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(new Vector2(0, 0), new Vector2(0, 0)) < 1)
        if (Vector2.Distance(transform.position, target.position) < range)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
            GetComponent<Rigidbody2D>().velocity = new Vector2();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}