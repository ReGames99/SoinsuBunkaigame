using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugDrop : MonoBehaviour
{ 
    [SerializeField] public static bool boxFlag; //ボックスの中にオブジェクトを吸い込んでいい時はFalse

    [SerializeField] private bool isColliding = false; // オブジェクトと接触しているかどうかのフラグ

    [SerializeField] public int dragNum; //自身の数字

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
        //ドラッグ中は吸い込んではだめ
        boxFlag = true;
        //以下四行はドラッグした時にオブジェクトを動かすコード
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        this.transform.position = worldPosition;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true; // オブジェクトと接触している
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }

    void OnMouseUp()
    {
        //ドラッグ終了、吸い込んでよし
        boxFlag = false;

        if(!isColliding) //isCollidingがfalseのとき初期位置に戻る
        {
            if(gameControlScript.initialPosFlag == true) //もし初期位置に球があるなら
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
