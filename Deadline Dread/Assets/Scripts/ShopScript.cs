using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update

    /*public int coins = SceneSwitchManager.coin;
    public int ammoLvl;
    public int speedLvl;*/
    public GameObject[] buttonList;
    public TextMeshProUGUI[] priceText;
    public TextMeshProUGUI balanceText;
    
    void Start()
    {
        for(int i = 0; i<SceneSwitchManager.abilityLevels.Length; i++)
        {
            UpdateText(i);
        }
        UpdateBalance();
        //SceneSwitchManager.coin = 999999;
    }

    public void UpdateBalance()
    {
        balanceText.text = "$" + SceneSwitchManager.coin.ToString();
    }

    public void UpdateText(int ID)
    {
        if(SceneSwitchManager.abilityLevels[ID] < SceneSwitchManager.LEVEL_MAX)
        {
            int price = SceneSwitchManager.abilityPriceByLevel[SceneSwitchManager.abilityLevels[ID]];
            priceText[ID].text = "$" + price.ToString() + " for Lv." + (SceneSwitchManager.abilityLevels[ID]+1).ToString();
        }
        else
        {
            priceText[ID].text = "MAX";
        }        
        
    }

    public void Buy(int ID)
    {
        
        if(SceneSwitchManager.abilityLevels[ID] < SceneSwitchManager.LEVEL_MAX)
        {
            int price = SceneSwitchManager.abilityPriceByLevel[SceneSwitchManager.abilityLevels[ID]];
            if(SceneSwitchManager.coin >= price)
            {
                SceneSwitchManager.coin -= price;
                SceneSwitchManager.abilityLevels[ID]+=1;
            
                UpdateText(ID);
                UpdateBalance();
            }
            else
            {
                buttonList[ID].GetComponent<ShopButtonScript>().flash();
            }            
        }
        else
        {
            buttonList[ID].GetComponent<ShopButtonScript>().flash();
        }

    }
    public void fireBuy()
    {
        Buy(SceneSwitchManager.FIRE_ID);
    }

    public void fanBuy()
    {
        Buy(SceneSwitchManager.FAN_ID);
    }

    public void ammoLvlBuy()
    {
        Buy(SceneSwitchManager.MAX_AMMO_ID);
    }

    public void speedBuy()
    {
        Buy(SceneSwitchManager.MAX_SPEED_ID);
    }

    public void accelBuy()
    {
        Buy(SceneSwitchManager.ACCEL_ID);
    }

    public void powerBuy()
    {
        Buy(SceneSwitchManager.POWER_ID);
    }
}
