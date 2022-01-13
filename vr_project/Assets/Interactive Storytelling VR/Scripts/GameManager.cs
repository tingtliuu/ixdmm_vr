using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCManager))]
[RequireComponent(typeof(DialogueManager))]

public class GameManager : MonoBehaviour
{
    
    public bool gameStart = false;
    public GameObject Player;   
    public GameObject UIFrame;   
    [HideInInspector] public bool noMoreInteraction;

    private void Start()
    {
        UIFrame.SetActive(true);
    }
}
