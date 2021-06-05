using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeAdjust : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetVolume(float value)
    {
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(value)*20);
    }
}
