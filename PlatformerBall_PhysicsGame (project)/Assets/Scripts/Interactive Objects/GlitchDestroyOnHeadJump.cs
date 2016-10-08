using UnityEngine;
using System.Collections;

public class GlitchDestroyOnHeadJump : MonoBehaviour {

	private GameObject thePlayer;
	public GameObject explosionParticles;
	
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Player") {
			GameObject go = Instantiate(explosionParticles, gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy(go, 1.0f);
			Destroy(gameObject.transform.parent.transform.parent.gameObject);
		}
	}


}
