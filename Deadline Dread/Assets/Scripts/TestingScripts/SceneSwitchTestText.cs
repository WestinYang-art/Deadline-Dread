using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneSwitchTestText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI deadline;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score = " + SceneSwitchManager.score.ToString();
        deadline.text = SceneSwitchManager.daysLeft.ToString() + "days left on dl " + SceneSwitchManager.deadlineNum.ToString() + ". target: " + SceneSwitchManager.deadlineGoals[SceneSwitchManager.deadlineNum].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
