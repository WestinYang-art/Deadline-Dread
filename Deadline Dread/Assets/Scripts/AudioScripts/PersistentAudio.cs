using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    //EXCLUSIVELY exists to let buttons finish their sfx during scene switch lololol
    public AudioSource asrc;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayThenDie(AudioClip aclip)
    {
        asrc.Stop();
        asrc.clip = aclip;
        asrc.Play();
        Destroy(gameObject, aclip.length);
    }

    public void Play(AudioClip aclip)
    {
        asrc.Stop();
        asrc.clip = aclip;
        asrc.Play();
    }
    
}
