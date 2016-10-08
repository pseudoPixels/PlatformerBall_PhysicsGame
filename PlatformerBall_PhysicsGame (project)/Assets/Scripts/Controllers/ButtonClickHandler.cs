using UnityEngine;
using System.Collections;


namespace UnitySampleAssets.CrossPlatformInput.PlatformSpecific
{
public class ButtonClickHandler : MonoBehaviour {

	public GameObject ball;
	BallController ballControllerScript;

	void Start(){
		ballControllerScript = ball.GetComponent<BallController> ();
	}


	public void hello(){
		//Debug.Log ("Cliked Me..");

		ballControllerScript.hInput = 1.0f;
	}

}

}
