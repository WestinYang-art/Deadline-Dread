using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    //variables which need to travel between scenes should be here
    public static int score;

    public static SceneSwitchManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
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

    public static void SwitchToMainMenu()
    {

    }

    public static void SwitchToShop()
    {

    }
    //add methods for any other scenes here. ex...
    /*
        main menu (separate from the menu in between runs)
        shop
        cutscenes*
            *these can be triggered within certain scenes instead of being a separate scene entirely. we'll see
    */
}
