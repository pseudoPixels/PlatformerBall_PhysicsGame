using UnityEngine;
using System.Collections;

public class BreakableWood : MonoBehaviour {

	public GameObject theBrokenRoundWood;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == "BloodSaw") {
			//Debug.Log("Collided with blood saw");
			Instantiate(theBrokenRoundWood, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
