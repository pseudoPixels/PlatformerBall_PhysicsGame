using UnityEngine;
using System.Collections;

public class KeySystem : MonoBehaviour {


	public GameObject gameobjectToInform;

	private Transform startingPosition;


	// Use this for initialization
	void Start () {
		startingPosition = gameObject.transform;
	}
	
	void OnCollisionStay2D(Collision2D other){
		gameobjectToInform.SendMessage ("OnKeyTouched");
		gameObject.renderer.material.color = Color.green;
		//Debug.Log ("key touched");
		//gameObject.transform.position = new Vector3 (gameObject.transform.position.x, keyDownLimit.position.y, gameObject.transform.position.z);
	}

	void OnCollisionExit2D(Collision2D other){
		gameobjectToInform.SendMessage ("OnKeyUntouched");
		gameObject.renderer.material.color = Color.white;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.collider2D.gameObject.name == "Ball")gameobjectToInform.SendMessage ("OnKeyTouchedByPlayer");
	}


}
