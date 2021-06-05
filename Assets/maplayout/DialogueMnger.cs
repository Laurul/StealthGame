using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMnger : MonoBehaviour
{
    public static DialogueMnger Instance;
    [SerializeField] List<DialogueObj> dialoguesTriggers;
    [SerializeField] KeyCode inputKey;
    [SerializeField] GameObject textPanel;
    [SerializeField] Text dialogue;
    [SerializeField] GameObject hudObj;
    List<GameObject> images;
    bool allow = false;
    int nr = 0;

    DialogueBox boxInstance;
    DialogueObj parentInstance;

    private void Start()
    {
       
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);

        DialogueObj[] allDialogues = FindObjectsOfType<DialogueObj>();
        foreach (DialogueObj dialogue in allDialogues)
        {
            dialoguesTriggers.Add(dialogue);
        }

        boxInstance = new DialogueBox();
        parentInstance = new DialogueObj();
        images = new List<GameObject>();
    }
    private void Update()
    {
        if (allow)
        {
            hudObj.SetActive(true);
            if (Input.GetKeyDown(inputKey))
            {

                if (nr < boxInstance.sentances.Length)
                {
                   
                    dialogue.text = boxInstance.sentances[nr];
                    nr++;
                }
                else
                {
                    nr = 0;
                    hudObj.SetActive(false);
                    if (images.Count != 0)
                    {
                        foreach (GameObject image in images)
                        {
                            image.SetActive(false);
                        }
                    }


                    //textPanel.SetActive(false);
                    dialoguesTriggers.Remove(parentInstance);
                    Destroy(parentInstance.gameObject);
                    Time.timeScale = 1;
                    allow = false;
                }
            }
        }
        
    }
    public void InitiateDialogue(DialogueBox dialogueObj,DialogueObj parent,List<GameObject> Objimages)
    {
        textPanel.SetActive(true);
        Time.timeScale = 0;
        images = Objimages;
        dialogue.text = dialogueObj.sentances[nr];
        nr++;
        allow = true;
        boxInstance = dialogueObj;
        parentInstance = parent;

       
    }
}
