using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculation : MonoBehaviour
{
    public static ScoreCalculation Instance;
    public static int runScore;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        runScore = 0;
    }
    public static void AddScore(int add)
    {
        SceneSwitchManager.score += add;
        runScore += add;
    }


}
