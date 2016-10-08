using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class MyBannerAd : MonoBehaviour {

	public string yourBannerAdID = "ca-app-pub-9495228888204546/3671306911";
	// Use this for initialization
	void Start () {
		RequestBanner ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = yourBannerAdID;
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}
}
