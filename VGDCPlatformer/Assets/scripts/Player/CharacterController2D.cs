using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in this namespace because its quiet worse than prime31,  the issue is prime 31 license means you 
// can't sell if you use it, but trust its very good and influenced the heck out of this controller.
namespace prime29{
public class CharacterController2D : MonoBehaviour {

		#region  layersToCOllideWith
		public LayerMask layers;
		#endregion
		// X and Y direction -1 -> 1 with 0 being none;



		[SerializeField]
		private int _xDirection, _yDirection=-1; // default so the drawgizmo is good looking.

		public float checkDistance;

		public Transform groundCast;// location of ground casts so we can kinda set where we wanna be verticall collision wise.
		

		void Start()
		{
			groundCast=transform.GetChild(0).GetComponentInChildren<Transform>();
			
		}

		public void move(Vector2 deltaMovement)
		{
			_xDirection = deltaMovement.x>=0 ? 1:-1;
			_yDirection = deltaMovement.y >= 0 ? 1 : -1;


			horizontalCollide(ref deltaMovement);
			verticalCollider(ref deltaMovement);

			transform.Translate(deltaMovement);



		}

		void horizontalCollide(ref Vector2 deltaMovement)
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(_xDirection, 0), checkDistance,layers);
			//Debug.DrawLine(transform.position, transform.position + new Vector3(_xDirection*checkDistance, 0,  0), Color.red);
			if (hit == false)
				return;
			deltaMovement.x = 0;
			
		}

		void verticalCollider(ref Vector2 deltaMovement)
		{
			RaycastHit2D hit = Physics2D.Raycast(groundCast.position,new Vector2(0, _yDirection), checkDistance,layers);
			//Debug.DrawLine(groundCast.position,groundCast.position + new Vector3(0, _yDirection*checkDistance, 0), Color.red);
			//Debug.Log(hit.collider);
			if(hit == false)
				return;
			deltaMovement.y = 0;
		}


		void OnDrawGizmos()
		{
		//	Gizmos.color = Color.green;
		//	Gizmos.DrawWireCube(transform.position, new Vector3(checkDistance, checkDistance, 0));
			Debug.DrawLine(groundCast.position,groundCast.position + new Vector3(0, _yDirection*checkDistance, 0), Color.red);
			Debug.DrawLine(transform.position, transform.position + new Vector3(_xDirection*checkDistance, 0,  0), Color.red);

		}
	}



}