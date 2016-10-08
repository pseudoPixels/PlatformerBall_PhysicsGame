using UnityEngine;
using System.Collections;

public class AutoSlideUpDown : MonoBehaviour {


	private bool moveUp = true;
	private bool moveDown = false;
	public float movementSpeed = 2.0f;
	public Transform upLimit;
	public Transform downLimit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moveUp) {
			gameObject.rigidbody2D.velocity = new Vector2 (0, movementSpeed);

		}
		if (moveDown) {
			gameObject.rigidbody2D.velocity = new Vector2 (0, -movementSpeed);

		}
		
		if (moveUp) {
			if (gameObject.transform.position.y >= upLimit.position.y) {
				moveUp = false;
				moveDown = true;
			}
		}
		
		
		
		if (moveDown) {
			if (gameObject.transform.position.y <= downLimit.position.y) {
				moveUp = true;
				moveDown = false;
				
			}
		}
	}
}
