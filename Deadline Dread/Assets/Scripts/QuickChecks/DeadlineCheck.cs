using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineCheck : MonoBehaviour
{
    [SerializeField] GameObject deadlineFailed;
    [SerializeField] GameObject deadlineReached;
    [SerializeField] GameObject vacation;
    [SerializeField] RoundEndingAudio sfx;
    void Start()
    {
        if(SceneSwitchManager.vacation)
        {
            //vacation
            vacation.SetActive(true);
            deadlineFailed.SetActive(false);
            deadlineReached.SetActive(false);
            sfx.playVacation();
        }
        else
        {
            if(SceneSwitchManager.currentDeadlineReached)
            {
                //deadline reached
                deadlineReached.SetActive(true);
                deadlineFailed.SetActive(false);
                vacation.SetActive(false);
                sfx.playSuccess();
            }
            else
            {
                //deadline failed
                deadlineFailed.SetActive(true);
                deadlineReached.SetActive(false);
                vacation.SetActive(false);
                sfx.playWomp();
            }
        }
    }
}
