using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="RPG Generator/Player/Attribute")]
public class Attributes : ScriptableObject
{

    public string Description;
    public Sprite Thumbnail;

    public Attributes(string description, Sprite thumbnail)
    {
        Description = description;
        Thumbnail = thumbnail;
    }
}
