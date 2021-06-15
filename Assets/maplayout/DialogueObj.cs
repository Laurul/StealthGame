using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObj : MonoBehaviour
{
    [SerializeField] DialogueBox box;
    public List<GameObject> images;
    [SerializeField] bool closeImges;
    [SerializeField] bool stopTime=true;
   //[SerializeField] DialogueMnger manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       DialogueMnger.Instance.InitiateDialogue(box, this,images,stopTime);
       
    }

    public bool shouldCLoseImages()
    {
        return closeImges;
    }

    public void ForceExecuteDialogue()
    {
        DialogueMnger.Instance.InitiateDialogue(box, this, images, stopTime);

    }
}
