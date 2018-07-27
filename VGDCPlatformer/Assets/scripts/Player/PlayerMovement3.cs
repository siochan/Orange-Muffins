using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using prime29;

public class PlayerMovement3 : MonoBehaviour {
	CharacterController2D _characterController;

	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement= new Vector2( Input.GetAxisRaw("Horizontal"),0f);
		_characterController.move(movement*.01f+Physics2D.gravity*Time.deltaTime);
	}
}
