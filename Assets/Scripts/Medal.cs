using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour
{
    public static int scoreCount;

    [SerializeField] GameObject bronz;
    [SerializeField] GameObject silver;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject diamond;

    void Start()
    {
        scoreCount = Score.scoreCount;

        MedalManage();
    }

 
    void MedalManage()
    {
        Debug.Log(scoreCount);
        if (scoreCount > 4)
        {
            PlayerPrefs.SetInt("bronz", 1);
            PlayerPrefs.Save();

            if (scoreCount > 6)
            {
                PlayerPrefs.SetInt("silver", 1);
                PlayerPrefs.Save();

                if (scoreCount > 9)
                {
                    PlayerPrefs.SetInt("gold", 1);
                    PlayerPrefs.Save();

                    if (scoreCount > 12)
                    {
                        PlayerPrefs.SetInt("diamond", 1);
                        PlayerPrefs.Save();

                        diamond.SetActive(true);
                    }
                    else
                    {
                        gold.SetActive(true);
                        Debug.Log("gold");
                    }
                }
                else
                {
                    silver.SetActive(true);
                    Debug.Log("silver");
                }
            }
            else
            {
                bronz.SetActive(true);
                Debug.Log("bronz");
            }
        }
    }
}
