using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropped : MonoBehaviour
{
    private Text num;

    int primeFactor;
    int exponent;

    public bool correctFlag; //数字が合っていたらtrue

    public Collider2D otherObject;

    Randomnum gameControlScript;

    public int otherNum = 1;

    private void Start() //Reload()したからと言ってゲームが始まるわけではない
    {
        gameControlScript = GameObject.Find("GameControl").GetComponent<Randomnum>();

        correctFlag = false;

    }

 

    public void Restart() 
    {
        correctFlag = false;

        GetList();
    }


    public void GetList()
    {
        if(gameObject.tag == "Exponent")
        {
            if (gameObject.activeSelf)
            {
                string num = gameObject.GetComponentInChildren<Text>().text; //.textで中身のstring
                int listNum = int.Parse(num);
                exponent = Randomnum.randomnumInstance.exponents[listNum]; //正解の数値 
                Debug.Log(exponent + "が正解");
            }
        }
        else
        {
            if (gameObject.activeSelf)
            {
                string num = gameObject.GetComponentInChildren<Text>().text; //.textで中身のstring
                int listNum = int.Parse(num);
                primeFactor = Randomnum.randomnumInstance.primeFactors[listNum]; //正解の数値 
                Debug.Log(primeFactor + "が正解");
            }
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!otherObject)
        {
            otherObject = collision;
        }
        
    }

    //トリガーに他のオブジェクトが接している間は処理を繰り返し実行
    void OnTriggerStay2D(Collider2D other)
    {
        DrugDrop dragdrop = other.gameObject.GetComponent<DrugDrop>();
        

        if(otherObject == other) //もし変数に格納されてるのと今接触してるものが同じなら
        {
            
            //boxFlagはドラッグ中はtrue、ドロップするとfalse
            if (DrugDrop.boxFlag == false)
            {
                //吸い込む（位置を合わせる）
                other.transform.position = this.transform.position;

                //吸い込み終わったらフラグ解放。つまり、吸い込んではだめな状態にする。
                DrugDrop.boxFlag = true;

                otherNum = dragdrop.dragNum;
                Debug.Log("otherNum = " + otherNum);

                //もし初期位置に球が無いなら、球を生成             
                if (gameControlScript.initialPosFlag == false)
                {
                    dragdrop.GenerateCloneObject();
                }

                if (gameObject.tag == "Exponent")
                {
                    if (dragdrop.dragNum == exponent)
                    {
                        correctFlag = true;
                    }

                }
                else
                {
                    //吸い込み終わったら判定し、合っていたらcorrectFlagをtrueに
                    if (dragdrop.dragNum == primeFactor)
                    {
                        correctFlag = true;
                    }
                }
            }
        }
        else
        {
            dragdrop.OnButtonDn();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(otherObject == other)
        {
            correctFlag = false;

            otherObject = null;
        }
        
    }

}
