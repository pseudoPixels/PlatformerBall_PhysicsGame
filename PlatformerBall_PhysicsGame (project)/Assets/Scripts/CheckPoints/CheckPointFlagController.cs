using UnityEngine;
using System.Collections;

public class CheckPointFlagController : MonoBehaviour {

	private bool riseUpThisFlag = false;
	public Transform flagMaxUpPosition;
	public float flagRiseUpSpeed = 1.50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (riseUpThisFlag && gameObject.transform.position.y <= flagMaxUpPosition.position.y) {
			gameObject.rigidbody2D.velocity = new Vector2 (0, flagRiseUpSpeed);
			//if(gameObject.transform.position.y >= flagMaxUpPosition.position.y)riseUpThisFlag = false;
			
		}
		else gameObject.rigidbody2D.velocity = new Vector2 (0, 0);
	}

	public void RiseUpTheFlag(){
		riseUpThisFlag = true;
	}
}
