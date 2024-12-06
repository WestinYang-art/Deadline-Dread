using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineCheck : MonoBehaviour
{
    [SerializeField] GameObject deadlineFailed;
    [SerializeField] GameObject deadlineReached;
    [SerializeField] GameObject vacation;
    void Start()
    {
        if(SceneSwitchManager.vacation)
        {
            vacation.SetActive(true);
            deadlineFailed.SetActive(false);
            deadlineReached.SetActive(false);
        }
        else
        {
            if(SceneSwitchManager.currentDeadlineReached)
            {
                deadlineReached.SetActive(true);
                deadlineFailed.SetActive(false);
                vacation.SetActive(false);
            }
            else
            {
                deadlineFailed.SetActive(true);
                deadlineReached.SetActive(false);
                vacation.SetActive(false);
            }
        }
    }
}
