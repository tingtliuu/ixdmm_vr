using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform destination;
    public GameObject[] npcs;
    public GameObject trigger;
    [SerializeField] Transform player;

    bool gameStart;
    [SerializeField] float speed = 1f;

    void triggerNpc(int e)

    {
        Vector3 npcPosition = npcs[e].transform.position;
        if (npcPosition.x < destination.transform.position.x)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            npcs[e].transform.position = Vector3.MoveTowards(npcPosition, (destination.position - new Vector3(0, destination.position.y, 0)), step);
        }
        else
        {
            npcs[e].transform.LookAt(player, Vector3.up);
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameStart = trigger.GetComponent<TriggerScript>().GameStart;
    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
            triggerNpc(0);
        }
    }
}
