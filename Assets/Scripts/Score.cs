using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score scoreInstance;

    public static int scoreCount;

    //public List<int> prizeScoreList;


    public void Awake()
    {
        if (scoreInstance == null)
        {
            scoreInstance = this;
        }
    }

    void Start()
    {
        //今までの入賞スコアリストを取得
        //prizeScoreList = new List<int>{
        //    PlayerPrefs.GetInt("score1", 0),
        //    PlayerPrefs.GetInt("score2", 0),
        //    PlayerPrefs.GetInt("score3", 0),
        //    PlayerPrefs.GetInt("score4", 0),
        //    PlayerPrefs.GetInt("score5", 0)};
    }

    

    public void ResultScore()
    {
        scoreCount = Randomnum.gameManagerScoreCount;
        Debug.Log("結果は" + scoreCount);       
    }


    public void UpdateScore()
    {
        if (scoreCount > PlayerPrefs.GetInt("score5", 0)) 
        {
            if (scoreCount > PlayerPrefs.GetInt("score4", 0))
            {
                PlayerPrefs.SetInt("score5", PlayerPrefs.GetInt("score4", 0));

                if (scoreCount > PlayerPrefs.GetInt("score3", 0))
                {
                    PlayerPrefs.SetInt("score4", PlayerPrefs.GetInt("score3", 0));

                    if (scoreCount > PlayerPrefs.GetInt("score2", 0))
                    {
                        PlayerPrefs.SetInt("score3", PlayerPrefs.GetInt("score2", 0));

                        if (scoreCount > PlayerPrefs.GetInt("score1", 0))
                        {
                            PlayerPrefs.SetInt("score2", PlayerPrefs.GetInt("score1", 0));
                            PlayerPrefs.SetInt("score1", scoreCount);
                            PlayerPrefs.Save();
                        }
                        else
                        {
                            PlayerPrefs.SetInt("score2", scoreCount);
                            PlayerPrefs.Save();
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("score3", scoreCount);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("score4", scoreCount);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetInt("score5", scoreCount); //prefsのscore1を今回のscoreCountに更新
                PlayerPrefs.Save();
            }
                
        }

    }

}
