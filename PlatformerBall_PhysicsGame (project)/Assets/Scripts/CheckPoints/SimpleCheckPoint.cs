using UnityEngine;
using System.Collections;

public class SimpleCheckPoint : MonoBehaviour {

	public GameObject theCheckPointFlag;


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {

			theCheckPointFlag.SendMessage("RiseUpTheFlag");

			PlayerPrefs.SetInt("IS_CHKP_REACHED", 1);
			PlayerPrefs.SetFloat("CHKP_X", other.gameObject.transform.position.x);
			PlayerPrefs.SetFloat("CHKP_Y", other.gameObject.transform.position.y);
			PlayerPrefs.SetFloat("CHKP_Z", other.gameObject.transform.position.z);
		}
	}
}
