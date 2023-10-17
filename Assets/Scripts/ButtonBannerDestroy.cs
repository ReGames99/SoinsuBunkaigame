using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBannerDestroy : MonoBehaviour
{
    private bool onMouseFlag;

    [SerializeField] GameObject bannerObject;



    private void OnMouseUp()
    {
        if (onMouseFlag == true)
        {
            DestroyAd();
        }
    }

    private void OnMouseEnter()
    {
        onMouseFlag = true;
    }

    private void OnMouseExit()
    {
        onMouseFlag = false;
    }


    void DestroyAd()
    {
        bannerObject.GetComponent<AdsMNG>().DestroyBanner();
    }
}