using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEDragDrop : MonoBehaviour
{

    //AudioSource��CD�v���C���[�ŃR���|�[�l���g
    AudioSource audioSource;

    //AudioClip��CD�ŉ���
    [SerializeField]
    AudioClip dragAudio;
    [SerializeField]
    AudioClip dropAudio;
    [SerializeField]
    bool dragFlag;

    void Start()
    {
        dragFlag = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        InvokeRepeating("DragSoundSource", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        dragFlag = true;
        
    }

    private void OnMouseUp()
    {
        dragFlag = false;
        audioSource.PlayOneShot(dropAudio);
    }

   
    void DragSoundSource()
    {
        if(dragFlag == true)
        {
            audioSource.PlayOneShot(dragAudio);
        }
        
    }
}
