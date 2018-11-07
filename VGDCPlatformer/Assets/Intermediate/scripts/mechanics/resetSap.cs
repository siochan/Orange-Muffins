using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSap : MonoBehaviour {

    private GameObject playerObj;
    CharacterController2D player;

    //private int previousAirJumps;


    // Use this for initialization
    void Start () {
        playerObj = GameObject.Find("Player(Advance)");
        player = playerObj.GetComponent<CharacterController2D>();
        //previousAirJumps = player.m_AirJumps;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            player.m_AirJumps = 1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
