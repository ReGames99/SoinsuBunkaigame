using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class InterstitialAdManager : MonoBehaviour
{
    // �����̍L�����j�b�g�́A��Ƀe�X�g�L����z�M����悤�ɐݒ肳��Ă��܂��B
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-9291243100348885/8258895904";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

    private InterstitialAd interstitialAd;

    [SerializeField] string loadName;

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>

    //Start()�֐���LoadInterstitialAd();�����s���邱�Ƃɂ�肱�̌�ɕ\�������L�����Z�b�g���Ă����܂��B
    public void Start()
    {
        // Google Mobile Ads SDK �����������܂��B
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // ���̃R�[���o�b�N�́AMobileAds SDK �������������ƌĂяo����܂��B
        });
        LoadInterstitialAd();
        Debug.Log("�L�������[�h");

    }

    public void LoadInterstitialAd()
    {
        // ���Ƀ��[�h����Ă���L��������Δj�����܂��B
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("�C���^�[�X�e�B�V�����L����ǂݍ���ł��܂��B");

        // �L����ǂݍ��ނ��߂Ɏg�p���郊�N�G�X�g���쐬���܂��B
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // �L����ǂݍ��ރ��N�G�X�g�𑗐M���܂��B
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
            // �G���[�� null �łȂ��ꍇ�A���[�h ���N�G�X�g�͎��s���܂����B
            if (error != null || ad == null)
                {
                    Debug.LogError("�C���^�[�X�e�B�V�����L�����L����ǂݍ��߂܂���ł��� " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("���X�|���X�𔺂��C���^�[�X�e�B�V�����L�����ǂݍ��܂�� : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;

                RegisterEventHandlers(interstitialAd);
                Debug.Log("�C�x���g�n���h���[�̓o�^");
                RegisterReloadHandler(interstitialAd);
                Debug.Log("���[�h�n���h���[�̓o�^");

            });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("�C���^�[�X�e�B�V�����L����\�����Ă��܂��B");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("�C���^�[�X�e�B�V�����L���͂܂��������ł��Ă��܂���B");
        }
    }

    //�C�x���g�n���h���[�̓o�^
    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // �L�������v���グ���Ɛ��肳���ꍇ�ɔ������܂��B
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // �L���̃C���v���b�V�������L�^�����Ƃ��ɔ������܂��B
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("�C���^�[�X�e�B�V�����L�����C���v���b�V�������L�^���܂����B");
        };
        // �L���̃N���b�N���L�^���ꂽ�Ƃ��ɔ������܂��B
        ad.OnAdClicked += () =>
        {
            Debug.Log("�C���^�[�X�e�B�V�����L�����N���b�N����܂����B");
        };
        // �L�����S��ʃR���e���c���J�����Ƃ��ɔ������܂��B
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("�C���^�[�X�e�B�V�����L���̑S��ʃR���e���c���J���܂����B");
        };
        // �L�����S��ʃR���e���c������Ƃ��ɔ������܂��B
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("�C���^�[�X�e�B�V�����L���̑S��ʃR���e���c�������܂����B");
            UnityEngine.SceneManagement.SceneManager.LoadScene(loadName);
        };
        // �L�����S��ʃR���e���c���J���Ȃ������ꍇ�ɔ������܂��B
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("�C���^�[�X�e�B�V�����L�����S��ʃR���e���c���J���܂���ł��� " +
                           "with error : " + error);
        };
    }


    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // �L�����S��ʃR���e���c������Ƃ��ɔ������܂��B
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("�C���^�[�X�e�B�V�����L���̑S��ʃR���e���c�������܂����B");

            // �ł��邾�������ʂ̍L����\���ł���悤�A�L���������[�h���Ă��������B
            LoadInterstitialAd();
        };
        // �L�����S��ʃR���e���c���J���Ȃ������ꍇ�ɔ������܂��B
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("�C���^�[�X�e�B�V�����L�����S��ʃR���e���c���J���܂���ł��� " +
                           "with error : " + error);

            // �ł��邾�������ʂ̍L����\���ł���悤�A�L���������[�h���Ă��������B
            LoadInterstitialAd();
        };
    }
}