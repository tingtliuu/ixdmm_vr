using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform destination;

    public GameObject[] npcs;

    public GameObject trigger;

    bool gameStart;

    void triggerNpc(int e)

    {
        if (destination.transform.position.x > npcs[e].transform.position.x)
        {
            npcs[e].transform.Translate(new Vector3(1, 0, 0) * (Time.deltaTime * 10));


        }

        else if (destination.transform.rotation.y > npcs[e].transform.rotation.y)
        {
            npcs[e].transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));

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
