using UnityEngine;
using System.Collections;

public class KeyMsgSender : MonoBehaviour {

	public GameObject theLock;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Ball") {
			//col.gameObject.SendMessage("PlayerDead");
			//Debug.Log("Player Entered");
			theLock.SendMessage("PlayerTouchedTheKey");
		}
	}
}
