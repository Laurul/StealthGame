using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougueTrigger : MonoBehaviour
{

    public DialougueObj dialogueObj;


    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().BeginDialogue(dialogueObj);
    }
}
