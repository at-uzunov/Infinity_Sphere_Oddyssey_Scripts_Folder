using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{
    public void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        LoadAd();

    }
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-2884502238056730/2814760829";
#elif UNITY_IPHONE
        private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        private string _adUnitId = "unused";
#endif
    BannerView _bannerView;


    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
         _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
    }
    public void DestroyBannerView()
{
    if (_bannerView != null)
    {
        Debug.Log("Destroying banner view.");
        _bannerView.Destroy();
        _bannerView = null;
    }
}
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }
} 