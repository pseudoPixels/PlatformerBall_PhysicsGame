using UnityEngine;
using System.Collections;

public class GlitchWalkerController : MonoBehaviour {

	public Transform leftLimit;
	public Transform rightLimit;
	
	private bool moveLeft = true;
	private bool moveRight = false;

	public float movementSpeed = 3.0f;

	bool facingRight = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (moveLeft) {
			gameObject.rigidbody2D.velocity = new Vector2 (-movementSpeed, 0);

		}
		if (moveRight) {
			gameObject.rigidbody2D.velocity = new Vector2 (movementSpeed, 0);

		}
		
		
		if (moveLeft) {
			if(gameObject.transform.position.x <= leftLimit.position.x){
				moveRight = true;
				moveLeft = false;
			}
		}
		
		if (moveRight) {
			if(gameObject.transform.position.x >= rightLimit.position.x){
				moveRight = false;
				moveLeft = true;
			}
		}

		if (rigidbody2D.velocity.x < 0 && facingRight)
			Flip ();
		else if(rigidbody2D.velocity.x >= 0 && !facingRight)
			Flip ();
		

	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1; 
		transform.localScale = theScale;

	}







}
