using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_CDFinish : MonoBehaviour
{
    
    void Start()
    {
        SoundEfect();
        Invoke("SEStop", 6);
    }

    void SoundEfect()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
        
    }
    void SEStop()
    {
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
