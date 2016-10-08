using UnityEngine;
using System.Collections;

public class SlideAndStay : MonoBehaviour {

	public bool isSlideRightToLeft = true;
	public Transform slideLimit;
	public float slideSpeed = 2.0f;

	private bool slideNow = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (slideNow == false)
			gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
		else {
			if(isSlideRightToLeft){
				if(gameObject.transform.position.x > slideLimit.position.x){
					gameObject.rigidbody2D.velocity = new Vector2 (-slideSpeed, 0);
				}else slideNow = false;
			}


			else{
				if(gameObject.transform.position.x < slideLimit.position.x){
					gameObject.rigidbody2D.velocity = new Vector2 (slideSpeed, 0);
				}else slideNow = false;
			}



		}

	}

	public void OnKeyTouched(){
		slideNow = true;
	}
	
	
	public void OnKeyUntouched(){


	}
}
