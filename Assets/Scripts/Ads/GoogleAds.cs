using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class GoogleAds : MonoBehaviour
{
    private InterstitialAd interstitial;



    public void ShowAndLoad()
    {
        loadInterstitialAd();

        showInterstitialAd();
    }

    public void loadInterstitialAd()
  {
#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-9291243100348885/8258895904";
#elif UNITY_IPHONE
    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    string adUnitId = "unexpected_platform";
#endif
        InterstitialAd.Load(adUnitId, new AdRequest(),
      (InterstitialAd ad, LoadAdError loadAdError) =>
      {
        if (loadAdError != null)
        {
          // Interstitial ad failed to load with error
          interstitial.Destroy();
          return;
        }
        else if (ad == null)
        {
          // Interstitial ad failed to load.
          return;
        }
        //L‚ð•Â‚¶‚½Žž‚É‚µ‚Á‚©‚è‚ÆDestroy‚·‚é
        ad.OnAdFullScreenContentClosed += () => {
          HandleOnAdClosed();
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
          HandleOnAdClosed();
        };
        interstitial = ad;
      });
  }

  private void HandleOnAdClosed()
  {
    this.interstitial.Destroy();
    this.loadInterstitialAd();

        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectStage");
    }

  public void showInterstitialAd()
  {
        if(interstitial != null)
        {
            Debug.Log("interstitial != null");
        }
        else if (interstitial == null)
        {
            Debug.Log("interstitial == null");
        }




        if (interstitial != null && interstitial.CanShowAd())
    {
      interstitial.Show();
    } else
    {
      Debug.Log("Interstitial Ad not load");
    }
  }
}
