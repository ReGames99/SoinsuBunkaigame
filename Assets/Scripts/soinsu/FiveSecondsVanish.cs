using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveSecondsVanish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FalseActive", GameObject.Find("GameControl").GetComponent<Randomnum>().timeNumber - 6);
    }

    void FalseActive()
    {
        gameObject.SetActive(false);
    }
}
