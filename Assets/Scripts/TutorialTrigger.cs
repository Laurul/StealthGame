using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class TutorialTrigger : MonoBehaviour
{
    [Tooltip("Use the bool if you want to move around the camera")]
    [SerializeField] bool useCamera;

    [SerializeField] FollowTarget camera;


    [Tooltip("Input vecotr for the desired position of the camera")]
    [SerializeField] Vector3 pos;

    [Tooltip("Use this bool if you want a certain object to activate when the player enters the trigger")]
    [SerializeField] bool activateGameObject;
    [SerializeField] GameObject activateOnTriggerEnter;

    Vector3 copy;
    DialougueTrigger dialogueTrigger;
    private void Awake()
    {
        dialogueTrigger = GetComponent<DialougueTrigger>();
        copy = camera.offset;
    }

    private void Update()
    {
      
    }
    private void OnTriggerStay(Collider other)
    {
       // GameManager.Instance.triggerDialogue = dialogueTrigger;

        dialogueTrigger.use = true;
        if (useCamera)
        {
            camera.offset = pos;
        }

        if (activateGameObject)
        {
            activateOnTriggerEnter.SetActive(true);
        }

        Destroy(this);
    }

   
}
