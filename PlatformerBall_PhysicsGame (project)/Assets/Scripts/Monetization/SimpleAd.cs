using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class SimpleAd : MonoBehaviour {

	void Awake () {
		Advertisement.Initialize ("1046006", true);
	}

	IEnumerator ShowAdWhenReady(){
		while(!Advertisement.IsReady())yield return null;
		Advertisement.Show ();
	}

	public void showAd(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show();
		}
	}

}
