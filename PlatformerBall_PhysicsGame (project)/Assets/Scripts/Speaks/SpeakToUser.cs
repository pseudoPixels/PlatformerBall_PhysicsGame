using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeakToUser : MonoBehaviour {


	public Image speakWindow;
	public Text speakText;


	private bool isSpeaking = false;
	private float elapsedTime = 0.0f;
	public float speakTimeLenght = 1.50f;
	public string whatToSpeak;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isSpeaking == true) {
			elapsedTime += Time.deltaTime;
			if(elapsedTime >= speakTimeLenght){
				isSpeaking = false;
				speakWindow.enabled = false;
				speakText.enabled = false;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "Ball") {
			speakWindow.enabled = true;
			speakText.enabled = true;
			speakText.text = whatToSpeak;
			isSpeaking = true;

			//Debug.Log("Should've speaked");
		}
	}


}
