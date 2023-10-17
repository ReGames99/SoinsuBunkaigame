using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalOnOff : MonoBehaviour
{

    [SerializeField] GameObject bronz;
    [SerializeField] GameObject silver;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject diamond;



    void Start()
    {
        if (PlayerPrefs.GetInt("bronz", 0) == 1)
        {
            if (PlayerPrefs.GetInt("silver", 0) == 1)
            {
                if (PlayerPrefs.GetInt("gold", 0) == 1)
                {
                    if (PlayerPrefs.GetInt("diamond", 0) == 1)
                    {
                        diamond.SetActive(true);

                    }
                    else
                    {
                        gold.SetActive(true);
                    }

                }
                else
                {
                    silver.SetActive(true);
                }

            }
            else
            {
                bronz.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
