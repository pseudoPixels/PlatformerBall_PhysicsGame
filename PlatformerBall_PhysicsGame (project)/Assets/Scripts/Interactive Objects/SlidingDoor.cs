using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {

	private bool openTheDoor = true;
	public float doorClosingSpeed = 10.0f;

	public Transform leftLimit;
	public Transform rightLimit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (openTheDoor == false) {
			if(gameObject.transform.position.x < rightLimit.position.x) rigidbody2D.velocity = new Vector2(doorClosingSpeed,0);
			else rigidbody2D.velocity = new Vector2(0,0);
		}

		if (openTheDoor == true ) {
			if(gameObject.transform.position.x > leftLimit.position.x) rigidbody2D.velocity = new Vector2(-doorClosingSpeed,0);
			else rigidbody2D.velocity = new Vector2(0,0);
		}
	}


	public void OnKeyTouched(){
		openTheDoor = false;
	}


	public void OnKeyUntouched(){
		openTheDoor = true;
//		Debug.Log ("Untouched...");
	}
}
