using UnityEngine;
using System.Collections;

public class CoinCollected : MonoBehaviour {


	public float rotationSpeed = -150.0f;

	public GameObject particleEffect;

	public AudioClip coinPickUpSound;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,rotationSpeed*Time.deltaTime);
		
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Ball") {
			//gameObject.rigidbody2D.velocity = new Vector3(0,5.0f, 0.0f);
			GameObject go =     Instantiate(particleEffect, rigidbody2D.position, Quaternion.identity) as GameObject;
			Destroy(go, 1.0f);
			rotationSpeed -= 150.0f;
			audio.PlayOneShot(coinPickUpSound);
			col.gameObject.SendMessage("AddCoins" , 10);
			Destroy(gameObject, 0.09f);
		}

		
	}
}
