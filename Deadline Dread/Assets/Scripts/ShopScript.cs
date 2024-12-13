using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update

    /*public int coins = SceneSwitchManager.coin;
    public int ammoLvl;
    public int speedLvl;*/
    void Start()
    {
        /*SceneSwitchManager.coin = 999999; // remember to remove this
        SceneSwitchManager.setMaxSLvl(0);
        SceneSwitchManager.setMaxALvl(0);*/
    }

    // Update is called once per frame
    void Update()
    {
        /*coins = SceneSwitchManager.coin;
        ammoLvl = SceneSwitchManager.getMaxALvl();
        speedLvl = SceneSwitchManager.getMaxSLvl();*/
    }

    public void ammoLvlBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl())) && SceneSwitchManager.getMaxALvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getMaxALvl() * SceneSwitchManager.getMaxALvl()));
            SceneSwitchManager.setMaxALvl(SceneSwitchManager.getMaxALvl() + 1);
        }
        else
        {

        }
    }

    public void speedBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl())) && SceneSwitchManager.getMaxSLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getMaxSLvl() * SceneSwitchManager.getMaxSLvl()));
            SceneSwitchManager.setMaxSLvl(SceneSwitchManager.getMaxSLvl() + 1);
        }
        else
        {
            
        }
    }

    public void fireBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl())) && SceneSwitchManager.getFireLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getFireLvl() * SceneSwitchManager.getFireLvl()));
            SceneSwitchManager.setFireLvl(SceneSwitchManager.getFireLvl() + 1);
        }
        else
        {

        }
    }
    public void fanBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl())) && SceneSwitchManager.getFanLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getFanLvl() * SceneSwitchManager.getFanLvl()));
            SceneSwitchManager.setFanLvl(SceneSwitchManager.getFanLvl() + 1);
        }
        else
        {

        }
    }
    public void accelBuy()
    {
        if (SceneSwitchManager.coin >= (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl())) && SceneSwitchManager.getAccelLvl() < 5)
        {
            SceneSwitchManager.coin -= (5 * (SceneSwitchManager.getAccelLvl() * SceneSwitchManager.getAccelLvl()));
            SceneSwitchManager.setAccelLvl(SceneSwitchManager.getAccelLvl() + 1);
        }
        else
        {

        }
    }
}
