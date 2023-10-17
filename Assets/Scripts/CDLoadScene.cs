using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDLoadScene : MonoBehaviour
{

    [SerializeField]
    public string loadSceneName;

    [SerializeField]
    AudioClip audioClip1;

    [SerializeField]
    AudioClip audioClip2;

    [SerializeField]
    AudioSource audioSource;

    void Start()
    {
        Invoke("LoadScene", 4.5f);

        Invoke("SoundEfect1", 0.4f);
        Invoke("SoundEfect1", 1.4f);
        Invoke("SoundEfect1", 2.4f);


        Invoke("SoundEfect2", 3.4f);
    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneName);
    }

    void SoundEfect1()
    {
        audioSource.PlayOneShot(audioClip1);
    }
    void SoundEfect2()
    {
        audioSource.PlayOneShot(audioClip2);
    }
}
