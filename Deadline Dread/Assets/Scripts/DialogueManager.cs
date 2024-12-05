using System.Collections;
using System.Collections.Generic;
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
    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    private string currentSpeaker;
    private const string BOSS = "boss";
    private const string MC = "mc"; 

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
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing. todo test if using z twice is bad
        if(Input.GetKeyDown(KeyCode.Z))
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
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
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
