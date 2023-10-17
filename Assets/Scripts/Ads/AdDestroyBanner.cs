using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdDestroyBanner : MonoBehaviour
{
    [SerializeField] int position;

    private BannerView bannerView;

    [SerializeField] GameObject bannerObject;

#if UNITY_ANDROID
    private string bannerUnitId = "ca-app-pub-9291243100348885/4439355801";
#elif UNITY_IPHONE
  private string bannerUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string bannerUnitId = "unused";
#endif

    void Start()
    {

        ShowBanner();
        //DestroyBanner();
        Invoke("DestroyBanner", 4f);
        //bannerObject.SetActive(true);
    }


    AdPosition AdPos()
    {
        if (position == 1)
        {
            return AdPosition.Bottom;
        }
        if (position == 2)
        {
            return AdPosition.TopLeft;
        }
        if (position == 3)
        {
            return AdPosition.TopRight;
        }
        if (position == 4)
        {
            return AdPosition.BottomLeft;
        }
        if (position == 5)
        {
            return AdPosition.BottomRight;
        }
        if (position == 6)
        {
            return AdPosition.Center;
        }
        return AdPosition.Top;
    }

    private void CreateBanner()
    {
        if (bannerView != null)
        {
            DestroyBanner();
        }
        bannerView = new BannerView(bannerUnitId, AdSize.Banner, AdPos());
    }

    private void DestroyBanner()
    {
        if (bannerView != null)
        {
            //bannerView.Hide();
            bannerView.Destroy();
            //bannerView = null;

            //GameObject.Find("BANNER(Clone)").SetActive(false);
        }
    }

    public void ShowBanner()
    {
        CreateBanner();

        //var adRequest = new AdRequest.Builder().Build();
        //adRequest.AddKeyword("unity-admob-sample education");

        AdRequest adRequest = new AdRequest();

        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("ロードされました - 表示します");
        };
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("ロード失敗しました");
        };
        bannerView.LoadAd(adRequest);
    }

}