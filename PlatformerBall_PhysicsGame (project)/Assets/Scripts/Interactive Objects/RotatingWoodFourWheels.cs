using UnityEngine;
using System.Collections;

public class RotatingWoodFourWheels : MonoBehaviour {


	public float rotationSpeed = -150.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,rotationSpeed*Time.deltaTime);
	}
}
