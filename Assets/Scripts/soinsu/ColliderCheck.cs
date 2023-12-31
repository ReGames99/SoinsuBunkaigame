using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderCheck : MonoBehaviour
{
    public int colliderCheckNum;

    GameObject gameControl;
    

    void Start()
    {
        gameControl = GameObject.Find("GameControl");

        string num = gameObject.GetComponentInChildren<Text>().text; //.textで中身のstring
        colliderCheckNum = int.Parse(num); //球の数値
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Randomnum gameControlScript = gameControl.GetComponent<Randomnum>();
        gameControlScript.initialPosFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Randomnum gameControlScript = gameControl.GetComponent<Randomnum>();
        gameControlScript.initialPosFlag = false;
    }
}
