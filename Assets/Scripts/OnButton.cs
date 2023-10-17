using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButton : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    public string loadSceneName;

    [SerializeField] GameObject bannerObject;

    //シーン切り替えをした時点で、前のシーンの音などはすべて消える（つまり1/60sしか流れない？）
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        gameObject.GetComponent<Button>().onClick.AddListener(PlayAndLoad);

    }

    void PlayMusic()
    {       
        audioSource.PlayOneShot(audioSource.clip);
    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
    }

    void PlayAndLoad()
    {
        bannerObject.GetComponent<AdsMNG>().DestroyBanner();
        PlayMusic();

        if(loadSceneName != null)
        {
            Invoke("LoadScene", 0.1f);
        }
        
    }
}
