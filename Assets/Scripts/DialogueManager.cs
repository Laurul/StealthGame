using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;
    public GameObject dialogueUI;
    private List<string> sentances;
    int sentanceIndex = 0;
    bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        sentances = new List<string>();
       
    }
    void Update()
    {
        if (finished)
        {
            sentanceIndex = 0;
            finished = false;
        }
           
    }

    public void BeginDialogue(DialougueObj dialogue)
    {
        
        Time.timeScale = 0;
        dialogueUI.SetActive(true);
       
        sentances.Clear();
       // print("DIALOGUE IS WORKING!!!");
        foreach(string sentence in dialogue.sentances)
        {
            sentances.Add(sentence);
        }
        print(dialogue.sentances.Length);
    }

     public void DisplaySentanceByIndex(int index)
    {
        if (sentanceIndex >= sentances.Count)
        {
            FinishDialogue();
            
            return;
        }
        //print(sentances[sentanceIndex]);
        dialogueText.text = sentances[sentanceIndex];
    }

    public void IncreaseIndex()
    {
        if (sentanceIndex <= sentances.Count-1)
        {
            sentanceIndex++;
        }
        //else sentanceIndex = 0;
    }

    public int ReturnIndex()
    {
        return sentanceIndex;
    }

    void FinishDialogue()
    {
        Time.timeScale = 1;
        //print("DIALOGUE FINISHED!!!");
        finished = true;
        dialogueUI.SetActive(false);
        
    }

    public bool GetFInished()
    {
        return finished;
    }
}
