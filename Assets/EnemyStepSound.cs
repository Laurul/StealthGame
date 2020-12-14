using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStepSound : MonoBehaviour
{
    [SerializeField] AudioClip[] footSteps;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Step()
    {
        AudioClip clip = PlayRandomClip();
        audioSource.PlayOneShot(clip);
    }
    // Update is called once per frame
   private AudioClip PlayRandomClip()
    {
        return footSteps[UnityEngine.Random.Range(0, footSteps.Length)];
    }
}
