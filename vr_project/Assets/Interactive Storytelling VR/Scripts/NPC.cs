using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class NPC : MonoBehaviour
{
    [HideInInspector] public GameObject GameManager;

    bool first = true;
    bool firstCheck = true;
    public bool isAtDestination;
    public bool interactionFinished;
    [HideInInspector] public bool  isYes, isNo;
    List<Dialogue> dialoguePackage;
    [SerializeField] Dialogue ScenarioDialogue;
    [SerializeField] Dialogue YesChoice;
    [SerializeField] Dialogue NoChoice;

    private void Start()
    {
        dialoguePackage = new List<Dialogue>();
        dialoguePackage.Add(ScenarioDialogue);
        dialoguePackage.Add(YesChoice);
        dialoguePackage.Add(NoChoice);
        GetComponent<DialogueTrigger>().init(dialoguePackage);
    }

    private void OnDestroy()
    {
        GameManager.GetComponent<NPCManager>().npcNumber++;
    }

    private void Update()
    {
       
        if (isAtDestination && first)
        {
            GetComponent<DialogueTrigger>().StartDialogue();
            first = false;
        }

        if (isAtDestination)
        {
            if (isYes && firstCheck)
            {
                firstCheck = false;
                Debug.Log(gameObject.name + " is a yes");
                GetComponent<DialogueTrigger>().loadDialogue(1);
            }
            else if (isNo && firstCheck)
            {
                firstCheck = false;
                Debug.Log(gameObject.name + " is a no");
                //interactionFinished = true;
                GetComponent<DialogueTrigger>().loadDialogue(2);

            }
            else if (isNo || isYes)
            {
                interactionFinished = GetComponent<DialogueTrigger>().dialogueManager.endOfConvo;
            }
        }
    }

}
