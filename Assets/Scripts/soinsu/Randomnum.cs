using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Randomnum : MonoBehaviour
{
    public Text displayText;

    //これは宣言のみ。
    public GameObject droppedCircle1;
    public GameObject droppedCircle2;
    public GameObject droppedCircle3;
    public GameObject droppedCircle4;
    public GameObject droppedCircle5;

    //int a = 1; int b = 2;みたいに初期化（最初の値を入れる）はできる。
    //int c = a+b; みたいに何かを参照して初期化することはできない。
    //public Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();

    public GameObject droppedExponentCircle1;
    public GameObject droppedExponentCircle2;
    public GameObject droppedExponentCircle3;
    public GameObject droppedExponentCircle4;
    public GameObject droppedExponentCircle5;


    public GameObject sign1;
    public GameObject sign2;
    public GameObject sign3;
    public GameObject sign4;

    public GameObject finishcanvas;

    public Text calculateResult;


    [SerializeField] public int timeNumber;
    [SerializeField] public GameObject CDObject;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;

    [SerializeField] GameObject homebutton;

    public bool initialPosFlag = false;

    bool badorcorrectFlag = false;


    //宣言と初期化を一緒にやっている。リスト自体はnullではない。中身はnull
    public List<int> primeFactors = new List<int>();
    public List<int> exponents = new List<int>();    //素数と指数を格納
    

    public Button button;

    //public static int calledCount = 0;
    public static  int gameManagerScoreCount;

    public static Randomnum randomnumInstance; //インスタンス変数の宣言


    public void Awake()
    {

        if (randomnumInstance == null)
        {
            randomnumInstance = this;
        }
    }



    //voidは戻り値なし。int A()はint型の値を出力。bool A()はtrue,falseを出力。
    public void Start()
    {
        Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();
        Dropped droppedCicleScript2 = droppedCircle2.GetComponent<Dropped>();
        Dropped droppedCicleScript3 = droppedCircle3.GetComponent<Dropped>();
        Dropped droppedCicleScript4 = droppedCircle4.GetComponent<Dropped>();
        Dropped droppedCicleScript5 = droppedCircle5.GetComponent<Dropped>();

        Dropped droppedExponentCicleScript1 = droppedExponentCircle1.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript2 = droppedExponentCircle2.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript3 = droppedExponentCircle3.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript4 = droppedExponentCircle4.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript5 = droppedExponentCircle5.GetComponent<Dropped>();

        GenerateNumAndFactorizeNum();

        AnActivateDroppedCircle();

        button.onClick.AddListener(CollectCheckNum);

        button.onClick.AddListener(CheckBadSE);

        Invoke("TimeFinish",timeNumber);
        Invoke("CDSet",timeNumber-6);

        droppedCicleScript1.GetList();
        droppedCicleScript2.GetList();
        droppedCicleScript3.GetList();
        droppedCicleScript4.GetList();
        droppedCicleScript5.GetList();

        droppedExponentCicleScript1.GetList();
        droppedExponentCicleScript2.GetList();
        droppedExponentCicleScript3.GetList();
        droppedExponentCicleScript4.GetList();
        droppedExponentCicleScript5.GetList();
    }

    void Update()
    {
        CalculateText();
    }


    void CDSet()
    {
        CDObject.SetActive(true);
    }

    int GenerateRandomNumber()
    {

        List<int> primeFactor = new List<int> { 2,4,8,16,32,3,9,27,81,5,25,125,7,49,11,121,
                                                13,169,17,6,12,18,24,36,54,72,30,
                                                10,20,50,40,100,15,45,75,
                                                14,28,21,63,35,42,
                                                22,44,33,55,77,99,66,110,
                                                26,39,34,51};


        int listnum = UnityEngine.Random.Range(0, primeFactor.Count - 1);
        int randomnumber = primeFactor[listnum];

        displayText.text = randomnumber.ToString();
        return randomnumber;

    }

    //int GenerateRandomNumber()
    //{
    //    List<int> primeFactor = new List<int> { 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3,
    //                                            5, 5, 5, 7, 7, 11, 11};

    //    List<int> availableNumbers = new List<int> { 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3,
    //                                                5, 5, 5, 7, 7, 11, 11};
    //    List<int> selectedNumbers = new List<int>();


    //    int c = UnityEngine.Random.Range(2, 5);

    //    int n = 17;

    //    for (int i = 0; i < c; i++)
    //    {           
    //        int listnum = UnityEngine.Random.Range(0, n);
    //        selectedNumbers.Add(availableNumbers[listnum]);
    //        availableNumbers.RemoveAt(listnum);
    //        n -= 1;
    //    }

    //    int randomnumber = 1;

    //    foreach (int number in selectedNumbers)
    //    {
    //        randomnumber *= number; // 各要素を積に掛け合わせる
    //    }

    //    displayText.text = randomnumber.ToString();
    //    return randomnumber;

    //}

    //int GenerateRandomNumber()
    //{
    //    int randomnumber = Random.Range(2, 200);
    //    displayText.text = randomnumber.ToString();
    //    return randomnumber;
    //}

    void FactorizeNumber(int number, List<int> primeFactors, List<int> exponents)
    {
        for (int i = 2; i <= number; i++)
        {
            int count = 0;
            while (number % i == 0)
            {
                number /= i;
                count++;
            }

            if (count > 0)
            {
                primeFactors.Add(i);
                exponents.Add(count);
            }
        }
    }

    void ActivateDroppedCircle()
    {
        droppedCircle2.gameObject.SetActive(true);
        droppedCircle3.gameObject.SetActive(true);
        droppedCircle4.gameObject.SetActive(true);
        droppedCircle5.gameObject.SetActive(true);

        droppedExponentCircle2.gameObject.SetActive(true);
        droppedExponentCircle3.gameObject.SetActive(true);
        droppedExponentCircle4.gameObject.SetActive(true);
        droppedExponentCircle5.gameObject.SetActive(true);

        sign4.gameObject.SetActive(true);
        sign3.gameObject.SetActive(true);
        sign2.gameObject.SetActive(true);
        sign1.gameObject.SetActive(true);
    }

    void AnActivateDroppedCircle()
    {
        if (primeFactors.Count < 5)
        {
            droppedCircle5.gameObject.SetActive(false);
            droppedExponentCircle5.gameObject.SetActive(false);

            sign4.gameObject.SetActive(false);

            if (primeFactors.Count < 4)
            {
                droppedCircle4.gameObject.SetActive(false);
                droppedExponentCircle4.gameObject.SetActive(false);

                sign3.gameObject.SetActive(false);

                if (primeFactors.Count < 3)
                {
                    droppedCircle3.gameObject.SetActive(false);
                    droppedExponentCircle3.gameObject.SetActive(false);

                    sign2.gameObject.SetActive(false);

                    if (primeFactors.Count < 2)
                    {
                        droppedCircle2.gameObject.SetActive(false);
                        droppedExponentCircle2.gameObject.SetActive(false);

                        sign1.gameObject.SetActive(false);
                    }
                }
            }
        }

    }


    void GenerateNumAndFactorizeNum()
    {
        int randomNum = GenerateRandomNumber();

        FactorizeNumber(randomNum, primeFactors, exponents);
    }
    

    

    //public bool CheckNumbers(InputField i, List<int> t, int n)
    //{
    //    int inputNumber;
    //    //iに入力された文字をinputNumber変数に格納できたら、チェックする
    //    if (int.TryParse(i.text, out inputNumber))
    //    {
    //        return inputNumber == t[n]; //inputfieldに入力された数がリストの
    //                                    //指定した数と同じなら、trueを返す

    //    }

    //    return false;
    //}

    

    void DroppedRestart()
    {
        Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();
        Dropped droppedCicleScript2 = droppedCircle2.GetComponent<Dropped>();
        Dropped droppedCicleScript3 = droppedCircle3.GetComponent<Dropped>();
        Dropped droppedCicleScript4 = droppedCircle4.GetComponent<Dropped>();
        Dropped droppedCicleScript5 = droppedCircle5.GetComponent<Dropped>();

        Dropped droppedExponentCicleScript1 = droppedExponentCircle1.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript2 = droppedExponentCircle2.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript3 = droppedExponentCircle3.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript4 = droppedExponentCircle4.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript5 = droppedExponentCircle5.GetComponent<Dropped>();

        droppedCicleScript1.Restart();
        droppedCicleScript2.Restart();
        droppedCicleScript3.Restart();
        droppedCicleScript4.Restart();
        droppedCicleScript5.Restart();

        droppedExponentCicleScript1.Restart();
        droppedExponentCicleScript2.Restart();
        droppedExponentCicleScript3.Restart();
        droppedExponentCicleScript4.Restart();
        droppedExponentCicleScript5.Restart();
    }

    void CollectCheckNum()
    {
        Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript1 = droppedExponentCircle1.GetComponent<Dropped>();

        if (droppedCicleScript1.correctFlag
            && droppedExponentCicleScript1.correctFlag)
        {
            if (primeFactors.Count == 1)
            {             
                Reload();
            }
            else
            {
                if (primeFactors.Count > 1)
                {
                    Dropped droppedCicleScript2 = droppedCircle2.GetComponent<Dropped>();
                    Dropped droppedExponentCicleScript2 = droppedExponentCircle2.GetComponent<Dropped>();
                    if (droppedCicleScript2.correctFlag
                        && droppedExponentCicleScript2.correctFlag)
                    {
                        if (primeFactors.Count == 2)
                        {
                            Reload();
                        }
                        else
                        {
                            if (primeFactors.Count > 2)
                            {
                                Dropped droppedCicleScript3 = droppedCircle3.GetComponent<Dropped>();
                                Dropped droppedExponentCicleScript3 = droppedExponentCircle3.GetComponent<Dropped>();
                                if (droppedCicleScript3.correctFlag
                                    && droppedExponentCicleScript3.correctFlag)
                                {                                  
                                    if (primeFactors.Count == 3)
                                    {
                                        Reload();
                                    }
                                    else
                                    {
                                        if (primeFactors.Count > 3)
                                        {
                                            Dropped droppedCicleScript4 = droppedCircle4.GetComponent<Dropped>();
                                            Dropped droppedExponentCicleScript4 = droppedExponentCircle4.GetComponent<Dropped>();
                                            if (droppedCicleScript4.correctFlag
                                                && droppedExponentCicleScript4.correctFlag)
                                            {                                             
                                                if (primeFactors.Count == 4)
                                                {
                                                    Reload();
                                                }
                                                else
                                                {
                                                    if (primeFactors.Count > 4)
                                                    {
                                                        Dropped droppedCicleScript5 = droppedCircle5.GetComponent<Dropped>();
                                                        Dropped droppedExponentCicleScript5 = droppedExponentCircle5.GetComponent<Dropped>();
                                                        if (droppedCicleScript5.correctFlag
                                                            && droppedExponentCicleScript5.correctFlag)
                                                        {                                                        
                                                            Reload();
                                                        }
                                                        
                                                    }
                                                }
                                            }
                                            
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                    
                }
            }
        }
        
    }

    void BadBuzzer()
    {
        badorcorrectFlag = false;
    }

    void CheckBadSE()
    {
        if(badorcorrectFlag == false)
        {
            BadSE();
        }
    }

    void BadSE()
    {
        audioSource.PlayOneShot(audioClip2);
    }
    void CorrectSE()
    {
        audioSource.PlayOneShot(audioClip1);
    }


    void TimeFinish()
    {

        Score.scoreInstance.ResultScore();
        Score.scoreInstance.UpdateScore();

        gameManagerScoreCount = 0;

        finishcanvas.SetActive(true);

        Invoke("LoadSceneToResult", 3);

        homebutton.SetActive(false);
        
    }

    void LoadSceneToResult()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }

    private void Reload()
    {
        badorcorrectFlag = true;

        CorrectSE();

        //生成された素因数を格納庫の中身を空にする
        primeFactors.Clear();
        exponents.Clear();

        gameManagerScoreCount++;
        Debug.Log("calldecountは"+gameManagerScoreCount);

        ActivateDroppedCircle();

        GenerateNumAndFactorizeNum();

        AnActivateDroppedCircle();

        DroppedRestart();

        calculateResult.text = "1";

        CalculateNumDelete();

        initialPosFlag = false;

        Invoke("BadBuzzer", 0.1f);
    }

    void CalculateText()
    {
        Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();
        Dropped droppedCicleScript2 = droppedCircle2.GetComponent<Dropped>();
        Dropped droppedCicleScript3 = droppedCircle3.GetComponent<Dropped>();
        Dropped droppedCicleScript4 = droppedCircle4.GetComponent<Dropped>();
        Dropped droppedCicleScript5 = droppedCircle5.GetComponent<Dropped>();

        Dropped droppedExponentCicleScript1 = droppedExponentCircle1.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript2 = droppedExponentCircle2.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript3 = droppedExponentCircle3.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript4 = droppedExponentCircle4.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript5 = droppedExponentCircle5.GetComponent<Dropped>();




        var a = Math.Pow(droppedCicleScript1.otherNum, droppedExponentCicleScript1.otherNum) *
                Math.Pow(droppedCicleScript2.otherNum, droppedExponentCicleScript2.otherNum) *
                Math.Pow(droppedCicleScript3.otherNum, droppedExponentCicleScript3.otherNum) *
                Math.Pow(droppedCicleScript4.otherNum, droppedExponentCicleScript4.otherNum) *
                Math.Pow(droppedCicleScript5.otherNum, droppedExponentCicleScript5.otherNum);

        calculateResult.text = a.ToString();
                
    }

    void CalculateNumDelete()
    {
        Dropped droppedCicleScript1 = droppedCircle1.GetComponent<Dropped>();
        Dropped droppedCicleScript2 = droppedCircle2.GetComponent<Dropped>();
        Dropped droppedCicleScript3 = droppedCircle3.GetComponent<Dropped>();
        Dropped droppedCicleScript4 = droppedCircle4.GetComponent<Dropped>();
        Dropped droppedCicleScript5 = droppedCircle5.GetComponent<Dropped>();

        Dropped droppedExponentCicleScript1 = droppedExponentCircle1.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript2 = droppedExponentCircle2.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript3 = droppedExponentCircle3.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript4 = droppedExponentCircle4.GetComponent<Dropped>();
        Dropped droppedExponentCicleScript5 = droppedExponentCircle5.GetComponent<Dropped>();


        droppedCicleScript1.otherNum = 1;
        droppedCicleScript2.otherNum = 1;
        droppedCicleScript3.otherNum = 1;
        droppedCicleScript4.otherNum = 1;
        droppedCicleScript5.otherNum = 1;
        droppedExponentCicleScript1.otherNum = 1;
        droppedExponentCicleScript2.otherNum = 1;
        droppedExponentCicleScript3.otherNum = 1;
        droppedExponentCicleScript4.otherNum = 1;
        droppedExponentCicleScript5.otherNum = 1;

    }

}
    
