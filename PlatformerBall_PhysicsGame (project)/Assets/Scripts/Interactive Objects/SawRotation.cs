using UnityEngine;
using System.Collections;

public class SawRotation : MonoBehaviour {

	public float rotationSpeed = -150.0f;
	public GameObject slidingBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(slidingBar.rigidbody2D.velocity.y != 0)transform.Rotate (0,0,rotationSpeed*Time.deltaTime);
		else transform.Rotate (0,0,0);
	}
}
