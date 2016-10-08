using UnityEngine;
using System.Collections;

public class PlayerLifeTaker : MonoBehaviour {

	private GameObject thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") {
			thePlayer.SendMessage("DecreaseLifeByOne");
		}
	}


}
