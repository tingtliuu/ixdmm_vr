using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    [SerializeField] private GameObject[] npcs;
    [SerializeField] private Transform destination;
    [SerializeField] private Transform NPCExit;
    [SerializeField] private float movementSpeed;
    public GameObject UIFrame;
    //[HideInInspector] public bool isInteractionOver;
    private Transform player;
    private bool gameStart;
    [HideInInspector] public int npcNumber = 0;
    private float intervall = 0.2f;
    private bool first = true;

    void Start()
    {
        player = GetComponent<GameManager>().Player.transform;
        foreach(GameObject npc in npcs)
        {
            npc.GetComponent<NPC>().GameManager = this.gameObject;

        }
    }

    // Update is called once per frame
    void Update()
    {
        gameStart = GetComponent<GameManager>().gameStart;
        
        if(npcs[0].GetComponent<NPC>().isAtDestination)
            UIFrame.SetActive(true);
        if (npcNumber == npcs.Length && first)
        {
            
            first = false;
            GetComponent<DialogueManager>().isInteractionOver = true;
            //Debug.Log(isInteractionOver);
        }
            
    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
           if(npcNumber != npcs.Length)
            triggerNpc(npcNumber);            
        }
    }

    void triggerNpc(int e)

    {
        
        NPC npc = npcs[e].GetComponent<NPC>();
        Vector3 npcPosition = npcs[e].transform.position;

        float distanceToTarget = Vector3.Distance(npcPosition, destination.position);

        if (npc.isAtDestination == false)
        {
            if (distanceToTarget < intervall)
            {
                npc.isAtDestination = true;
            }

            npcs[e].transform.position = Vector3.MoveTowards(npcPosition, destination.position, movementSpeed * Time.deltaTime);
        }
        else if (npc.isAtDestination && npc.interactionFinished == false)
        {
            npcs[e].transform.LookAt((player.position - new Vector3(0,player.position.y,0)), Vector3.up);
        }

        if (npc.interactionFinished)
        {
            npcs[e].transform.LookAt((NPCExit.position - new Vector3(0, NPCExit.position.y, 0)), Vector3.up);
            npcs[e].transform.position = Vector3.MoveTowards(npcPosition, NPCExit.position, movementSpeed * Time.deltaTime);
        }

    }

    public void sendChoice(bool choice)
    {
        if (npcNumber != npcs.Length)
        {
            if (choice)
                npcs[npcNumber].GetComponent<NPC>().isYes = true;
            else
                npcs[npcNumber].GetComponent<NPC>().isNo = true;
        }
    }
}
