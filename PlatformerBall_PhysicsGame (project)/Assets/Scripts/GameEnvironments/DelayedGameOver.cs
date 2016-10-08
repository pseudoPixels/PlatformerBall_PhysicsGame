using UnityEngine;
using System.Collections;

public class DelayedGameOver : MonoBehaviour {

	public float delayTime = 5.0f;
	private float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= delayTime) {
			int playerAvailableLife = PlayerPrefs.GetInt("PLAYER_LIFE");
			if(playerAvailableLife > 0 )Application.LoadLevel(PlayerPrefs.GetString("LAST_LEVEL"));
			else Application.LoadLevel ("Game Over");
			
		}
	}
}
