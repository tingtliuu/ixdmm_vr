using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [HideInInspector] public GameObject GameManager;
    
    public bool isAtDestination;
    public bool interactionFinished;
    bool first = true;
    bool first1 = true;
    public Dialogue ScenarioDialogue;
    public Dialogue YesChoice;
    public Dialogue NoChoice;
    private DialoguePackage dialoguePackage;
    // Start is called before the first frame update

    private void Start()
    {
        //dialoguePackage = new DialoguePackage();
        //Debug.Log(dialoguePackage.dialogues[0]);

        //Debug.Log(dialoguePackage.dialogues[0].sentences);
        //
        // dialoguePackage.dialogues[0] = ScenarioDialogue;


    }
    private void OnDestroy()
    {
        GameManager.GetComponent<NPCManager>().npcNumber++;
        
    }
    private void Update()
    {
        if (isAtDestination && first)
        {
            first = false;
            triggerNPCDialogue();
            //Set Canavs to visible
        }
        if (interactionFinished)
        {
            first1 = false;
            //sett canvas invisible
        }
    }

    public void triggerNPCDialogue()
    {
        //Debug.Log(dialoguePackage.dialogues[0].sentences); //Trigger dialogue button
    }
}
