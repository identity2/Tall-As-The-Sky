using GoogleMobileAds.Api;
using UnityEngine;

public class RequestAdMob : MonoBehaviour {
	void Start() {
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3679599074148025/3035669918";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3679599074148025/9461477461";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
    	BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
    	// Create an empty ad request.
    	AdRequest request = new AdRequest.Builder().Build();
    	// Load the banner with the request.
    	bannerView.LoadAd(request);
	}
}
