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
    public static int fireLvl;
    public static int fanLvl;
    //public static int regenLvl;
    public static int maxALvl;
    public static int maxSLvl;
    public static int accelLvl;
    public static int powerLvl;

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
        deadlineGoals = new int[] {2000, 2500, 3000};
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
        return fireLvl;
    }

    public static void setFireLvl(int nFireLvl)
    {
        fireLvl = nFireLvl;
    }

    public static int getFanLvl()
    {
        return fanLvl;
    }

    public static void setFanLvl(int nFanLvl)
    {
        fanLvl = nFanLvl;
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
        return maxALvl;
    }

    public static void setMaxALvl(int nMaxALvl)
    {
        maxALvl = nMaxALvl;
    }
    public static int getMaxSLvl()
    {
        return maxSLvl;
    }

    public static void setMaxSLvl(int nMaxSLvl)
    {
        maxSLvl = nMaxSLvl;
    }
    public static int getAccelLvl()
    {
        return accelLvl;
    }

    public static void setAccelLvl(int nAccelLvl)
    {
        accelLvl = nAccelLvl;
    }
    public static int getPowerLvl()
    {
        return powerLvl;
    }

    public static void setPowerLvl(int nPowerLvl)
    {
        powerLvl = nPowerLvl;
    }
}
