using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineCheck : MonoBehaviour
{
    [SerializeField] GameObject deadlineFailed;
    [SerializeField] GameObject deadlineReached;
    void Start()
    {
        if(SceneSwitchManager.currentDeadlineReached)
        {
            deadlineReached.SetActive(true);
            deadlineFailed.SetActive(false);
        }
        else
        {
            deadlineFailed.SetActive(true);
            deadlineReached.SetActive(false);
        }
    }
}
