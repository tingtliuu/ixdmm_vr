using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public string _name;
    [TextArea(3,10)]
    public string[] sentences;
    
}

public class DialoguePackage : ScriptableObject
{
    [TextArea(3, 10)]
    public Dialogue[] dialogues;
}

