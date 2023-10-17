using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdsMNG : MonoBehaviour
{
    [SerializeField] int position;

    private BannerView bannerView;



#if UNITY_ANDROID
    private string bannerUnitId = "ca-app-pub-9291243100348885/4439355801";
#elif UNITY_IPHONE
  private string bannerUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string bannerUnitId = "unused";
#endif



    AdPosition AdPos()
    {
        if(position  == 1)
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

    public void DestroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }

    public void ShowBanner()
    {
        CreateBanner();

        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample education")
            .Build();

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