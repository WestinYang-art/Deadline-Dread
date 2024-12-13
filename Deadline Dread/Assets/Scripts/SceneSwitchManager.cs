using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    //variables which need to travel between scenes should be here. put their initial values in Reset()
    public static int score;
    //have we reached the current deadline target?
    public static bool currentDeadlineReached;
    //what deadline are we on?
    public static int deadlineNum;

    //currently hard-coded to 2 per deadline
    public static int daysLeft;
    //all score goals for deadlines
    public static int[] deadlineGoals;
    public static bool vacation;
    public static bool introTime;
    public static int coin;
    public static int healthLvl;

    /*public static int fireLvl;
    public static int fanLvl;
    //public static int regenLvl;
    public static int maxALvl;
    public static int maxSLvl;
    public static int accelLvl;
    public static int powerLvl;*/
    

    //shop level-able things
    public static int[] abilityLevels;
    public static int[] abilityPriceByLevel;
    public const int FIRE_ID = 0;
    public const int FAN_ID = 1;
    public const int MAX_AMMO_ID = 2;
    public const int MAX_SPEED_ID = 3;
    public const int ACCEL_ID = 4;
    public const int POWER_ID = 5;
    public const int LEVEL_MAX = 5;
    

    public static SceneSwitchManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Reset();
        DontDestroyOnLoad(gameObject);
    }

    public static void SwitchToPlaying()
    {
        //put name of playing scene here
        SceneManager.LoadScene("PlayingSceneForUITesting");
    }

    //this switches to the menu from BETWEEN runs. NOT the main menu
    public static void SwitchToMenu()
    {
        //put name of menu scene here
        SceneManager.LoadScene("UITest");
    }

    //this is supposed to switch to the start/main menu, but we don't have one yet
    public static void SwitchToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public static void SwitchToShop()
    {
        SceneManager.LoadScene("Shop"); 
    }

    public static void SwitchToRoundEnd()
    {
        if(!vacation && score >= deadlineGoals[deadlineNum]) currentDeadlineReached = true;
        SceneManager.LoadScene("RoundEnding");
    }

    public static void SwitchToDialogue()
    {
        SceneManager.LoadScene("DialogueCutscene");
    }

    //add methods for any other scenes here

    public static void NextDeadline()
    {
        deadlineNum++;
        daysLeft = 2;
        score = 0;
        currentDeadlineReached = false;
        //this is an extremely temporary measure for debugging. WILL be removed
        if(deadlineNum > deadlineGoals.Length-1)
        {
            vacation = true;
        }
    }

    //reset data to initial values for restarting game
    public static void Reset()
    {
        vacation = false;
        introTime = true;
        currentDeadlineReached = false;
        coin = 0;
        deadlineNum = 0;
        daysLeft = 2;
        score = 0;

        abilityLevels = new int[6];
        abilityPriceByLevel = new int[LEVEL_MAX+1];
        for(int i = 0; i<6; i++)
        {
            abilityLevels[i] = 1;
            //this is where prices are set.
            abilityPriceByLevel[i] = i * (i+1) * 5;
        }     

        /*fireLvl = 1;
        fanLvl = 1;
        maxALvl = 1;
        maxSLvl = 1;
        accelLvl = 1;
        powerLvl = 1;*/
        deadlineGoals = new int[] {2000, 5000, 12345};
    }

    public static void addCoin(int amount)
    {
        coin += amount;
    }

    public static void removeCoin(int amount)
    {
        if ((coin - amount) >= 0)
        {
            coin -= amount;
        }
        else
        {
            coin = 0;
        }
    }

    public static int getHealthLvl()
    {
        return healthLvl;
    }

    public static void setHealthLvl(int nHealthLvl)
    {
        healthLvl = nHealthLvl;
    }

    public static int getFireLvl()
    {
        return abilityLevels[FIRE_ID];
    }

    public static void setFireLvl(int nFireLvl)
    {
        abilityLevels[FIRE_ID] = nFireLvl;
    }

    public static int getFanLvl()
    {
        return abilityLevels[FAN_ID];
    }

    public static void setFanLvl(int nFanLvl)
    {
        abilityLevels[FAN_ID] = nFanLvl;
    }

    /*public static int getRegenLvl()
    {
        return regenLvl;
    }

    public static void setRegenLvl(int nRegenLvl)
    {
        regenLvl = nRegenLvl;
    }*/

    public static int getMaxALvl()
    {
        return abilityLevels[MAX_AMMO_ID];
    }

    public static void setMaxALvl(int nMaxALvl)
    {
        abilityLevels[MAX_AMMO_ID] = nMaxALvl;
    }
    public static int getMaxSLvl()
    {
        return abilityLevels[MAX_SPEED_ID];
    }

    public static void setMaxSLvl(int nMaxSLvl)
    {
        abilityLevels[MAX_SPEED_ID] = nMaxSLvl;
    }
    public static int getAccelLvl()
    {
        return abilityLevels[ACCEL_ID];
    }

    public static void setAccelLvl(int nAccelLvl)
    {
        abilityLevels[ACCEL_ID] = nAccelLvl;
    }
    public static int getPowerLvl()
    {
        return abilityLevels[POWER_ID];
    }

    public static void setPowerLvl(int nPowerLvl)
    {
        abilityLevels[POWER_ID] = nPowerLvl;
    }
}
