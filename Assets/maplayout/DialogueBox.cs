using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "RPG Generator/Player/DialogueBox")]

public class DialogueBox : ScriptableObject
{
    [TextArea]
    public string[] sentances;
}
