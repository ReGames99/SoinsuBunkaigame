using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    public Button selectStage;
    public Button again;

    public Text score;

    public Text prizeScore;

    
    void Start()
    {
        int count = Score.scoreCount;
        Debug.Log("結果は"+count);

        //スコア表示
        string scoreCount = count.ToString();
        score.text =  scoreCount;

        DisplayScoreList();
    }


    
    void DisplayScoreList()
    {

        prizeScore.text = "1th. " + PlayerPrefs.GetInt("score1", 0).ToString() + "\n" +
                          "2th. " + PlayerPrefs.GetInt("score2", 0) + "\n" +
                          "3th. " + PlayerPrefs.GetInt("score3", 0) + "\n" +
                          "4th. " + PlayerPrefs.GetInt("score4", 0) + "\n" +
                          "5th. " + PlayerPrefs.GetInt("score5", 0) + "\n" ;

    }



}
