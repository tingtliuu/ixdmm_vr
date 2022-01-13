using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCManager))]
[RequireComponent(typeof(DialogueManager))]

public class GameManager : MonoBehaviour
{
    
    public bool gameStart = false;
    public GameObject Player;   
    [HideInInspector] public bool noMoreInteraction;

    
}
