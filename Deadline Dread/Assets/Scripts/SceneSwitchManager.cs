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
        SceneManager.LoadScene("UITest");
    }

    public static void SwitchToShop()
    {

    }

    public static void SwitchToRoundEnd()
    {
        if(score >= deadlineGoals[deadlineNum]) currentDeadlineReached = true;
        SceneManager.LoadScene("RoundEnding");
    }

    public static void SwitchToDialogue()
    {
        SceneManager.LoadScene("DialogueTest");
    }
    //add methods for any other scenes here

    public static void NextDeadline()
    {
        deadlineNum++;
        daysLeft = 2;
        score = 0;
        currentDeadlineReached = false;
        //this is an extremely temporary measure for debugging. WILL be removed
        if(deadlineNum > deadlineGoals.Length-1) deadlineNum = 0;
    }

    //reset data to initial values for restarting game
    public static void Reset()
    {
        currentDeadlineReached = false;
        deadlineNum = 0;
        daysLeft = 2;
        deadlineGoals = new int[] {100, 200, 300};
    }
}
