using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugDrop : MonoBehaviour
{ 
    [SerializeField] public static bool boxFlag; //�{�b�N�X�̒��ɃI�u�W�F�N�g���z������ł�������False

    [SerializeField] private bool isColliding = false; // �I�u�W�F�N�g�ƐڐG���Ă��邩�ǂ����̃t���O

    [SerializeField] public int dragNum; //���g�̐���

    private Vector3 initialPosition;

    public Button button;

    Randomnum gameControlScript;


    private void Start()
    {
        gameControlScript = GameObject.Find("GameControl").GetComponent<Randomnum>();

        initialPosition = transform.position;

        button.onClick.AddListener(OnButtonDn);

        
    }

    void OnMouseDrag()
    {
        //�h���b�O���͋z������ł͂���
        boxFlag = true;
        //�ȉ��l�s�̓h���b�O�������ɃI�u�W�F�N�g�𓮂����R�[�h
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        this.transform.position = worldPosition;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true; // �I�u�W�F�N�g�ƐڐG���Ă���
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }

    void OnMouseUp()
    {
        //�h���b�O�I���A�z������ł悵
        boxFlag = false;

        if(!isColliding) //isColliding��false�̂Ƃ������ʒu�ɖ߂�
        {
            if(gameControlScript.initialPosFlag == true) //���������ʒu�ɋ�������Ȃ�
            {
                Destroy(gameObject);
            }
            else
            {
                OnButtonDn();
            }

            
        }
        
        
    }

    public void OnButtonDn()
    {
        transform.position = initialPosition;
    }

    public void GenerateCloneObject()
    {
        GameObject clonedObject = Instantiate(gameObject);
        

        GameObject canvasObject = GameObject.Find("Canvas");
        clonedObject.transform.SetParent(canvasObject.transform, false);

        clonedObject.transform.position = initialPosition;
    }
}
