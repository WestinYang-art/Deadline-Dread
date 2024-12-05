using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTestTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)) DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
