using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCManager))]
public class GameManager : MonoBehaviour
{
    
    public bool gameStart = false;
    public GameObject Player;   
    [HideInInspector] public bool noMoreInteraction;
}
