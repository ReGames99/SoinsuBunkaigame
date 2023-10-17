using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleMobileAdsInitializer : MonoBehaviour
{
    void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log(initStatus);
        });

        gameObject.GetComponent<AdsMNG>().ShowBanner();
    }
}