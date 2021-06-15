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
    int i = 0;

    DialogueBox boxInstance;
    DialogueObj parentInstance;

    string story = "";
    float timeLeft = 0.25f;
    private void Start()
    {
        dialogue.text = "";

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

            timeLeft -= Time.deltaTime;
            print(story.Length);
            if (dialogue.text.Length < story.Length && timeLeft >= 0)
            {
                dialogue.text += story[i];
               // story += dialogue.text[i];
                i++;

            }
            else if (timeLeft < 0)
            {
                timeLeft = 0.25f;
            }


            hudObj.SetActive(true);

            if (nr <= images.Count)
            {
                if (images[nr - 1] != null)
                    images[nr - 1].SetActive(true);

                if (nr > 1 && images[nr - 2] != null)
                {
                    images[nr - 2].SetActive(false);
                }
            }
            if (Input.GetKeyDown(inputKey))
            {

               


                if (nr < boxInstance.sentances.Length)
                {

                    
                    i = 0;
                    story = boxInstance.sentances[nr];
                    nr++;
                    dialogue.text = "";



                }
                else
                {

                    hudObj.SetActive(false);
                    if (images.Count != 0 && parentInstance.shouldCLoseImages())
                    {
                        foreach (GameObject image in images)
                        {
                            if (image != null)
                                image.SetActive(false);
                        }
                    }
                   

                    //textPanel.SetActive(false);
                    dialoguesTriggers.Remove(parentInstance);
                    Destroy(parentInstance.gameObject);
                    Time.timeScale = 1;
                    allow = false;
                    nr = 0;

                }
            }
        }

    }
    public void InitiateDialogue(DialogueBox dialogueObj, DialogueObj parent, List<GameObject> Objimages, bool timescale)
    {
        textPanel.SetActive(true);
        if (timescale)
        {
            Time.timeScale = 0;
        }

        images = Objimages;
        story = dialogueObj.sentances[nr];
        nr++;
        allow = true;
        boxInstance = dialogueObj;
        parentInstance = parent;


    }
}
