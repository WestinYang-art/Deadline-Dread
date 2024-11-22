using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneSwitchTestText : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score = " + SceneSwitchManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
