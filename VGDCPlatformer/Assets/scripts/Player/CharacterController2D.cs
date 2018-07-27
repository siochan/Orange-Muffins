using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Notes for continuing development:
		Using bounding boxes as set up points for where to start shooting casts.
		set the casts to be density based so that it will always end at the end of the bounding box
		figure out the fast long cast thing? (am I doing the same thing that they did? should I be checking my collisions every frame, should I push myself out?)
	 	Build a nice af editor and gizmos scripts for figuring out whats happening (stretch af goal)

 */




// in this namespace because its quiet worse than prime31,  the issue is prime 31 license means you 
// can't sell if you use it, but trust its very good and influenced the heck out of this controller.
namespace prime29{
public class CharacterController2D : MonoBehaviour {

		#region  Collision handling important
		public LayerMask layers;
        public int castCounts;
		private Collider2D _boxColldier;

        #endregion
        // X and Y direction -1 -> 1 with 0 being none;


       

        [SerializeField]
		private int _xDirection, _yDirection=-1; // default so the drawgizmo is good looking.

		public float checkDistance;

		public Transform groundCast;// location of ground casts so we can kinda set where we wanna be verticall collision wise.
		
		#region  helperFunctions
		Vector3 TransformPlus(float x, float y, float z)
		{
			return new Vector3( transform.position.x+x, transform.position.y+y,transform.position.z+z);
		}
		Vector3 TransformPlus(float x, float y, float z, Vector3 other)
		{
			return new Vector3(other.x + x, other.y + y, other.z + z);
		}

		#endregion
		
		void Start()
		{
			groundCast=transform.GetChild(0).GetComponentInChildren<Transform>();
            _boxColldier= GetComponent<Collider2D>();
		}

		public void move(Vector2 deltaMovement)
		{
			_xDirection = deltaMovement.x>=0 ? 1:-1;
			_yDirection = deltaMovement.y >= 0 ? 1 : -1;


			horizontalCollide(ref deltaMovement);
			verticalCollider(ref deltaMovement);

			transform.Translate(deltaMovement);



		}

		#region checks and balances

		void horizontalCollide(ref Vector2 deltaMovement)
		{
			float rayDistances=0;
			for(int i = 0; i<castCounts ; i++){
				RaycastHit2D hit = Physics2D.Raycast(TransformPlus(0,rayDistances,0,_boxColldier.bounds.min), new Vector2(_xDirection, 0), checkDistance, layers);
				Debug.DrawLine(TransformPlus(0, rayDistances, 0, _boxColldier.bounds.min), TransformPlus(0, rayDistances, 0, _boxColldier.bounds.min) + new Vector3(_xDirection * checkDistance, 0, 0), Color.red);
				rayDistances+=.5f;
				if(hit==true)
				{
					deltaMovement.x = 0;
					return;
				}
			}
			
			//Debug.DrawLine(transform.position, transform.position + new Vector3(_xDirection*checkDistance, 0,  0), Color.red);
			

			
		}

		void verticalCollider(ref Vector2 deltaMovement)
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(0, _yDirection), checkDistance,layers);
			//Debug.DrawLine(groundCast.position,groundCast.position + new Vector3(0, _yDirection*checkDistance, 0), Color.red);
			//Debug.Log(hit.collider);
			if(hit == false)
				return;
			deltaMovement.y = 0;
		}
		
		#endregion

		void OnDrawGizmos()
		{
		//	Gizmos.color = Color.green;
		//	Gizmos.DrawWireCube(transform.position, new Vector3(checkDistance, checkDistance, 0));
			Debug.DrawLine(transform.position,transform.position + new Vector3(0, _yDirection*checkDistance, 0), Color.red);

		}
	}



}