using UnityEngine;
using System.Collections;

public class RespondToKeyEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnKeyTouchedByPlayer(){
		gameObject.rigidbody2D.gravityScale = 1.50f;


	}
}
