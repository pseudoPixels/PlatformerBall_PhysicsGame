using UnityEngine;
using System.Collections;

public class SlideUpOnKeyDown : MonoBehaviour {

	private bool moveUp = true;
	private bool moveDown = false;
	public float movementSpeed = 2.0f;
	public Transform upLimit;
	public Transform downLimit;
	public GameObject rotatingSaw;
	private SawRotation sr;
	private bool isLocked = true;

	// Use this for initialization
	void Start () {
		sr = rotatingSaw.GetComponent<SawRotation> ();
	}



	public void UnlockYourself(){
		isLocked = false;

	}

	public void LockYourself(){
		isLocked = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocked == false) {

			if (moveUp) {
				gameObject.rigidbody2D.velocity = new Vector2 (0, movementSpeed);
				sr.rotationSpeed = -Mathf.Abs (sr.rotationSpeed);
			}
			if (moveDown) {
				gameObject.rigidbody2D.velocity = new Vector2 (0, -movementSpeed);
				sr.rotationSpeed = Mathf.Abs (sr.rotationSpeed);
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

		if (isLocked == true) {
			gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
		}

	}
}
