using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndingAudio : MonoBehaviour
{
    
    public AudioSource asrc;
    public AudioClip wompWomp;
    public AudioClip success;
    public AudioClip vacation;
    
    public void playWomp()
    {
        asrc.Stop();
        asrc.clip = wompWomp;
        asrc.Play();
    }

    public void playSuccess()
    {
        asrc.Stop();
        asrc.clip = success;
        asrc.Play();
    }

    public void playVacation()
    {
        asrc.Stop();
        asrc.clip = vacation;
        asrc.Play();
    }
}
