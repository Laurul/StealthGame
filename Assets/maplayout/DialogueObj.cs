using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObj : MonoBehaviour
{
    [SerializeField] DialogueBox box;
    public List<GameObject> images;
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
       DialogueMnger.Instance.InitiateDialogue(box, this,images);
        if (images.Count != 0)
        {
            foreach(GameObject image in images)
            {
                image.SetActive(true);
            }
        }
    }
}
