using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class NPC : MonoBehaviour
{
    [HideInInspector] public GameObject GameManager;

    bool first = true;
    public bool isAtDestination;
    public bool interactionFinished;
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

    private void Update()
    {
        if (isAtDestination && first)
        {
            GetComponent<DialogueTrigger>().StartDialogue();
            first = false;
        }

        if (interactionFinished)
        {
            GetComponent<DialogueTrigger>().loadDialogue(2);
            interactionFinished = false;
        }
    }

}
