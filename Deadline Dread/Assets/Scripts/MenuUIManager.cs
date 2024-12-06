using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreTargetText;
    [SerializeField] TextMeshProUGUI deadlineDaysText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = SceneSwitchManager.score.ToString();
        scoreTargetText.text = SceneSwitchManager.deadlineGoals[SceneSwitchManager.deadlineNum].ToString();
        deadlineDaysText.text = SceneSwitchManager.daysLeft.ToString();
    }
}
