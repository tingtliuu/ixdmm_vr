using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [HideInInspector] public Teleport Teleport;
    public bool DebugMode, TriggerTP;
    private void OnTriggerEnter(Collider other)
    {
        bool noMoreInteraction = Teleport.GetComponent<GameManager>().noMoreInteraction;
        
        if (other.gameObject.tag == "Player" && noMoreInteraction)
        {
            Teleport.activateTeleport = true;
        }
    }

    private void Update()
    {
        if (DebugMode && TriggerTP)
        {
            Teleport.activateTeleport = true;
            TriggerTP = false;
        }
    }
}
