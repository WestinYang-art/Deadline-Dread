using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    [SerializeField] private GameObject bossPanel;
    [SerializeField] private GameObject mcPanel;
    [SerializeField] private TextMeshProUGUI bossText;
    [SerializeField] private TextMeshProUGUI mcText;
    [SerializeField] private AudioClip[] mcSFX;
    [SerializeField] private AudioClip[] bossSFX;
    [SerializeField] private AudioSource asrc;
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    private string currentSpeaker;
    private const string BOSS = "boss";
    private const string MC = "mc"; 
    //these play AFTER the dialogue
    [SerializeField] private TextAsset[] deadlineDialogues;

    private const string SPEAKER_TAG = "speaker";

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("wtf there's another dialogue manager");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        bossPanel.SetActive(false);
        mcPanel.SetActive(false);
        if(SceneSwitchManager.introTime)EnterDialogueMode(deadlineDialogues[deadlineDialogues.Length - 1]);
        else EnterDialogueMode(deadlineDialogues[SceneSwitchManager.deadlineNum]);        
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing. left click for that
        if(Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying=false;
        bossPanel.SetActive(false);
        bossText.text = "";
        mcPanel.SetActive(false);
        mcText.text = "";
        
        if(SceneSwitchManager.introTime) SceneSwitchManager.introTime = false;        
        else SceneSwitchManager.NextDeadline();
        if(SceneSwitchManager.vacation) SceneSwitchManager.SwitchToRoundEnd();
        else SceneSwitchManager.SwitchToMenu();
    }

    private void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            HandleTags(currentStory.currentTags);
            if(currentSpeaker == BOSS)
            {
                bossPanel.SetActive(true);
                bossText.text = currentStory.Continue();
                mcPanel.SetActive(false);
                mcText.text = "";
            }
            else
            {
                //we're just going to ASSUME that if it's not the boss, it's the MC. FOR NOW.
                mcPanel.SetActive(true);
                mcText.text = currentStory.Continue();
                bossPanel.SetActive(false);
                bossText.text = "";
            }
            Noises();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void Noises()
    {
        System.Random r = new System.Random();
        asrc.Stop();
        if(currentSpeaker == BOSS)
        {
            asrc.clip = bossSFX[r.Next(0, bossSFX.Length)];
        }
        //again, assuming it's mc if it's not boss
        else
        {
            asrc.clip = mcSFX[r.Next(0, mcSFX.Length)];
        }
        asrc.Play();
    }

    private void HandleTags(List<string> currentTags)
    {
         foreach(string tag in currentTags)
         {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagVal = splitTag[1].Trim();
            switch(tagKey)
            {
                case SPEAKER_TAG:
                    if(tagVal == BOSS || tagVal == MC) currentSpeaker = tagVal;
                    else
                    {
                        Debug.Log("unknown speaker");
                        StartCoroutine(ExitDialogueMode());
                    }
                    break;
                default:
                    Debug.Log("bro tf these tags");
                    break;
            }
         }
    }
}
