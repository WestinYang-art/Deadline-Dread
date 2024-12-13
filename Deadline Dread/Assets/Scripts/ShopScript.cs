using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update

    /*public int coins = SceneSwitchManager.coin;
    public int ammoLvl;
    public int speedLvl;*/
    public GameObject[] buttonList;
    public GameObject[] buttonText;
    void Start()
    {
        buttonText[0].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl())).ToString();
        buttonText[1].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl())).ToString();
        buttonText[2].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl())).ToString();
        buttonText[3].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl())).ToString();
        buttonText[4].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl())).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*coins = SceneSwitchManager.coin;
        ammoLvl = SceneSwitchManager.getMaxALvl();
        speedLvl = SceneSwitchManager.getMaxSLvl();*/
    }

    public void fireBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl())) && SceneSwitchManager.getFireLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl()));
            SceneSwitchManager.setFireLvl(SceneSwitchManager.getFireLvl() + 1);
            buttonText[0].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl())).ToString();
            if (SceneSwitchManager.getFireLvl() >= 5)
            {
                buttonText[0].GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
            }
        }
        else
        {
            buttonList[0].GetComponent<ShopButtonScript>().flash();
        }
    }

    public void fanBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl())) && SceneSwitchManager.getFanLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl()));
            SceneSwitchManager.setFanLvl(SceneSwitchManager.getFanLvl() + 1);
            buttonText[1].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl())).ToString();
            if (SceneSwitchManager.getFanLvl() >= 5)
            {
                buttonText[1].GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
            }
        }
        else
        {
            buttonList[1].GetComponent<ShopButtonScript>().flash();
        }
    }

    public void ammoLvlBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl())) && SceneSwitchManager.getMaxALvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl()));
            SceneSwitchManager.setMaxALvl(SceneSwitchManager.getMaxALvl() + 1);
            buttonText[2].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl())).ToString();
            if (SceneSwitchManager.getMaxALvl() >= 5)
            {
                buttonText[2].GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
            }
        }
        else
        {
            buttonList[2].GetComponent<ShopButtonScript>().flash();
        }
    }

    public void speedBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl())) && SceneSwitchManager.getMaxSLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl()));
            SceneSwitchManager.setMaxSLvl(SceneSwitchManager.getMaxSLvl() + 1);
            buttonText[3].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl())).ToString();
            if (SceneSwitchManager.getMaxSLvl() >= 5)
            {
                buttonText[3].GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
            }
        }
        else
        {
            buttonList[3].GetComponent<ShopButtonScript>().flash();
        }
    }

    public void accelBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl())) && SceneSwitchManager.getAccelLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl()));
            SceneSwitchManager.setAccelLvl(SceneSwitchManager.getAccelLvl() + 1);
            buttonText[4].GetComponent<TMPro.TextMeshProUGUI>().text = "$" + (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl())).ToString();
            if (SceneSwitchManager.getAccelLvl() >= 5)
            {
                buttonText[4].GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
            }
        }
        else
        {
            buttonList[4].GetComponent<ShopButtonScript>().flash();
        }
    }
}
