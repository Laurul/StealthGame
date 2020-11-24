using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougueTrigger : MonoBehaviour
{

    public DialougueObj dialogueObj;
    public bool use;

    public void DialogueTrigger()
    {
        if (use)
        {
            FindObjectOfType<DialogueManager>().BeginDialogue(dialogueObj);
            use = false;
        }
      
    }
}
