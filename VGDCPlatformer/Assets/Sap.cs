using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sap : MonoBehaviour {
    public int reducedSpeed = 5;                            // the desired speed we want when player is moving through the sap
    public float reduceJumpPower = 300f;

    private float previousJumpPower;
    private float heavy;
    private float previousRunSpeed;                         // store original run speed so that it can change back when exiting sap
    private float slowDown;                                 // will be used to get the desired reduced speed

    private GameObject playerObj;
    PlayerMove player;
    CharacterController2D player2;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("Player(Advance)");
        player = playerObj.GetComponent<PlayerMove>();
        player2 = playerObj.GetComponent<CharacterController2D>();
        previousRunSpeed = player.runSpeed;
        previousJumpPower = player2.m_JumpForce;
        heavy = previousJumpPower - reduceJumpPower;
        slowDown = previousRunSpeed - reducedSpeed;        // currentSpeed - slowDown = reducedSpeed => slowDown = previousSpeed - reduced speed
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player.runSpeed);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            player.runSpeed -= slowDown;                // subtract orignal speed by slowDown to always obtain desired speed (reducedSpeed)
            player2.m_JumpForce -= heavy;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            player.runSpeed = previousRunSpeed;         // when player exits sap, return the run speed back to normal
            player2.m_JumpForce = previousJumpPower;
    }
}
