using UnityEngine;
using System.Collections;

public class GameWon : MonoBehaviour {

	public float delayTime = 10.0f;
	private float elapsedTime = 0.0f;
	private bool isGameWon = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameWon) {
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= delayTime)Application.LoadLevel ("Game Won");
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Ball") {
			if(PlayerPrefs.GetInt ("NUMBER_OF_COMP_LEVELS") < PlayerPrefs.GetInt ("CURRENT_LEVEL_SERIAL")){
				PlayerPrefs.SetInt ("NUMBER_OF_COMP_LEVELS", PlayerPrefs.GetInt ("CURRENT_LEVEL_SERIAL"));
			}
			isGameWon = true;
		}
			
	}
}
