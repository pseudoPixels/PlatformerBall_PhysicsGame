using UnityEngine;
using System.Collections;

public class SimpleSlideUp : MonoBehaviour {

	private bool slideUp = false;

	public float slideSpeed = 2.0f;
	public Transform upLimit;
	public Transform downLimit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (slideUp == false){
			if( gameObject.transform.position.y > downLimit.position.y)gameObject.rigidbody2D.velocity = new Vector2 (0, -Mathf.Abs(slideSpeed));
			else gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
		}
			

		if (slideUp == true) {
			if(gameObject.transform.position.y < upLimit.position.y)gameObject.rigidbody2D.velocity = new Vector2 (0, Mathf.Abs(slideSpeed));
			else gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
		}
			

	}

	public void OnKeyTouched(){
		slideUp = true;
	}

	public void OnKeyUntouched(){
		slideUp = false;
	}
}
