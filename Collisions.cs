using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Collisions : MonoBehaviour
{
    GameObject cnvs;
    GameObject paused;
    void Start()
    {
        cnvs = GameObject.Find("Canvas");
        paused = GameObject.FindGameObjectWithTag("PauseMenu");
        paused.gameObject.SetActive(false);
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            LoadLoadInterstitialAd();
        });

    }
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-2884502238056730/3169984049";
    private InterstitialAd _interstitialAd;
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif
    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        int shields = PlayerPrefs.GetInt("Shields",0);
        if (collision.gameObject.tag == "Coins")
        {
            int coins = PlayerPrefs.GetInt("Coins", 0);
            coins += 1;
            PlayerPrefs.SetInt("Coins", coins);
            /* Debug.Log("current coins: " + coins); */
            Destroy(collision.gameObject);
            AudioManager.Instance.PlaySFX("Coins");
        }
        else if (collision.gameObject.tag == "CloneObject"  && shields == 0)
        {
           int number = Random.Range(0, 20);
            if (number == 10)
            {
                ShowInterstitialAd();
            }
            paused.gameObject.SetActive(true);
            Time.timeScale = 0;
            cnvs.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Walls")
        {
            paused.gameObject.SetActive(true);
            Time.timeScale = 0;
            cnvs.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "CloneObject" && shields > 0)
        {
            shields -= 1;
            PlayerPrefs.SetInt("Shields", shields);
        }
        else if (collision.gameObject.tag == "ShieldClone")
        {
            AudioManager.Instance.PlaySFX("Shields");
            shields += 1;
            PlayerPrefs.SetInt("Shields", shields);
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Obj1(Clone)")
        {
            int current_score = PlayerPrefs.GetInt("Current_Score", 0);
            current_score += 1;
            PlayerPrefs.SetInt("Current_Score", current_score);
            /* Debug.Log("Score Increased! New Score: " + current_score); */

        }
    }



}
