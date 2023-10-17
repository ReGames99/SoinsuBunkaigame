using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownSE : MonoBehaviour
{

    [SerializeField] AudioSource audioSource1;


    void Start()
    {
        Invoke("PlaySE1", GameObject.Find("GameControl").GetComponent<Randomnum>().timeNumber-6);
        Invoke("StopSE", GameObject.Find("GameControl").GetComponent<Randomnum>().timeNumber);
    }

    void PlaySE1()
    {
        audioSource1.PlayOneShot(audioSource1.clip);
    }

    void StopSE()
    {
        audioSource1.Stop();
    }

}
