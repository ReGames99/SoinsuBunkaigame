using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    Vector2 initialPos;

    [SerializeField] GameObject shadeImage;

    AudioSource audioSource;

    [SerializeField]
    public string loadSceneName;

    private bool onMouseFlag;



    private void Start()
    {
        initialPos = transform.position;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(shadeImage.transform.position.x, shadeImage.transform.position.y);
    }

    private void OnMouseUp()
    {
        transform.position = initialPos;

        if(onMouseFlag == true)
        {
            PlayAndLoad();
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
        PlayMusic();
        Invoke("LoadScene", 0.1f);
    }
}