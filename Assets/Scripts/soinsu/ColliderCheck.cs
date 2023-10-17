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

        string num = gameObject.GetComponentInChildren<Text>().text; //.text�Œ��g��string
        colliderCheckNum = int.Parse(num); //���̐��l
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
