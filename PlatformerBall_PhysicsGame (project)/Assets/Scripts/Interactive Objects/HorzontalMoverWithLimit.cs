using UnityEngine;
using System.Collections;

public class HorzontalMoverWithLimit : MonoBehaviour {


	public Transform leftLimit;
	public Transform rightLimit;

	private bool moveLeft = true;
	private bool moveRight = false;

	private RotatingWoodFourWheels rw;

	public bool isRotationAllowed = true;


	public float movementSpeed = 3.0f;
	// Use this for initialization
	void Start () {
		rw = GetComponent<RotatingWoodFourWheels> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveLeft) {
			gameObject.rigidbody2D.velocity = new Vector2 (-movementSpeed, 0);
			if(isRotationAllowed)rw.rotationSpeed = Mathf.Abs(rw.rotationSpeed);
		}
		if (moveRight) {
			gameObject.rigidbody2D.velocity = new Vector2 (movementSpeed, 0);
			if(isRotationAllowed)rw.rotationSpeed = -Mathf.Abs(rw.rotationSpeed);
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




	}
}
