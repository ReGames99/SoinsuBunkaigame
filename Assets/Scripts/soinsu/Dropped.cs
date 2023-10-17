using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropped : MonoBehaviour
{
    private Text num;

    int primeFactor;
    int exponent;

    public bool correctFlag; //�����������Ă�����true

    public Collider2D otherObject;

    Randomnum gameControlScript;

    public int otherNum = 1;

    private void Start() //Reload()��������ƌ����ăQ�[�����n�܂�킯�ł͂Ȃ�
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
                string num = gameObject.GetComponentInChildren<Text>().text; //.text�Œ��g��string
                int listNum = int.Parse(num);
                exponent = Randomnum.randomnumInstance.exponents[listNum]; //�����̐��l 
                Debug.Log(exponent + "������");
            }
        }
        else
        {
            if (gameObject.activeSelf)
            {
                string num = gameObject.GetComponentInChildren<Text>().text; //.text�Œ��g��string
                int listNum = int.Parse(num);
                primeFactor = Randomnum.randomnumInstance.primeFactors[listNum]; //�����̐��l 
                Debug.Log(primeFactor + "������");
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

    //�g���K�[�ɑ��̃I�u�W�F�N�g���ڂ��Ă���Ԃ͏������J��Ԃ����s
    void OnTriggerStay2D(Collider2D other)
    {
        DrugDrop dragdrop = other.gameObject.GetComponent<DrugDrop>();
        

        if(otherObject == other) //�����ϐ��Ɋi�[����Ă�̂ƍ��ڐG���Ă���̂������Ȃ�
        {
            
            //boxFlag�̓h���b�O����true�A�h���b�v�����false
            if (DrugDrop.boxFlag == false)
            {
                //�z�����ށi�ʒu�����킹��j
                other.transform.position = this.transform.position;

                //�z�����ݏI�������t���O����B�܂�A�z������ł͂��߂ȏ�Ԃɂ���B
                DrugDrop.boxFlag = true;

                otherNum = dragdrop.dragNum;
                Debug.Log("otherNum = " + otherNum);

                //���������ʒu�ɋ��������Ȃ�A���𐶐�             
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
                    //�z�����ݏI������画�肵�A�����Ă�����correctFlag��true��
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
