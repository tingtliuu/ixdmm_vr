using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    [SerializeField] private GameObject[] npcs;
    [SerializeField] private Transform destination;
    [SerializeField] private float movementSpeed;
    private Transform player;
    private bool gameStart;
    private int npcNumber = 0;

    void Start()
    {
        player = GetComponent<GameManager>().Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameStart = GetComponent<GameManager>().gameStart;
    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
            if (npcs[npcNumber].GetComponent<NPC>().interactionFinished && npcNumber != npcs.Length - 1)
            {
                npcNumber++;                
            }
            
                triggerNpc(npcNumber);
            
        }
    }

    void triggerNpc(int e)

    {
        
        NPC npc = npcs[e].GetComponent<NPC>();
        Vector3 npcPosition = npcs[e].transform.position;

        float distanceToTarget = Vector3.Distance(npcPosition, destination.position);
        
        if (distanceToTarget < .3f)
        {
            npc.isAtDestination = true;
        }
        Debug.Log(npc.isAtDestination);
        if (npc.isAtDestination == false)
        {
            npcs[e].transform.position = Vector3.MoveTowards(npcPosition, destination.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            npcs[e].transform.LookAt((player.position - new Vector3(0,player.position.y,0)), Vector3.up);
        }
        
    }


    public void nextNPC()
    {

    }
}
