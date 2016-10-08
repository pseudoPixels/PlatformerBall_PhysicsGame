using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	/*void Awake () {
		Advertisement.Initialize ("1046006", true);
	}*/

	public string yourUnityAdGameID = "1046006";
	IEnumerator Start ()
	{
		#if !UNITY_ADS // If the Ads service is not enabled...
		if (Advertisement.isSupported) { // If runtime platform is supported...
			Advertisement.Initialize(yourUnityAdGameID, false); // ...initialize.
		}
		#endif
		
		// Wait until Unity Ads is initialized,
		//  and the default ad placement is ready.
		while (!Advertisement.isInitialized || !Advertisement.IsReady()) {
			yield return new WaitForSeconds(0.5f);
		}
		
		// Show the default ad placement.
		//Advertisement.Show();
	}



	public void showAd(string zone = ""){
		#if UNITY_EDITOR
				//StartCoroutine(WaitForAdToShow());
		#endif

		if (string.Equals (zone, "")) {
			zone = null;
		}


		ShowOptions options = new ShowOptions ();
		options.resultCallback = AdCallbackHandler;

		if (Advertisement.IsReady (zone)) {
			Advertisement.Show(zone, options);
		}


	}

	void AdCallbackHandler(ShowResult result){
		switch (result) {
			case ShowResult.Finished:
				PlayerPrefs.SetInt("PLAYER_LIFE", 1);
				Application.LoadLevel(PlayerPrefs.GetString("LAST_LEVEL"));
			break;

			case ShowResult.Skipped:
				//Ad skipped. No reward.

			break;

			case ShowResult.Failed:
				//Something went wrong. No reward.
			break;



		}


	}






	IEnumerator WaitForAdToShow(){
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
	}


}
