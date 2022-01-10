using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public GameObject GameManager;
    public bool isAtDestination;
    public bool interactionFinished;
    // Start is called before the first frame update

    private void OnDestroy()
    {
        GameManager.GetComponent<NPCManager>().npcNumber++;
    }
}
