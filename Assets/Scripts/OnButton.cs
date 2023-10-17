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

    //�V�[���؂�ւ����������_�ŁA�O�̃V�[���̉��Ȃǂ͂��ׂď�����i�܂�1/60s��������Ȃ��H�j
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
