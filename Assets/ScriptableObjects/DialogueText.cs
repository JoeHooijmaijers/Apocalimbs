using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName ="NPC/Dialogue")]
public class DialogueText : ScriptableObject
{

    public new string name;

    [TextArea(2, 4)]
    public string[] dialogue;

}
