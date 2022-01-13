using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]

public class WorldNarritive : MonoBehaviour
{
    bool first = true;
    bool first1 = true;
    bool isInteractionOver;
    [HideInInspector] public bool teleportDoll;
    List<Dialogue> dialoguePackage;
    [SerializeField] Dialogue MainWorldDialogue;
    [SerializeField] Dialogue MirrorWorldDialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialoguePackage = new List<Dialogue>();
        dialoguePackage.Add(MainWorldDialogue);
        dialoguePackage.Add(MirrorWorldDialogue);
        
    }

    // Update is called once per frame
    void Update()
    {
        isInteractionOver = GetComponent<DialogueTrigger>().dialogueManager.isInteractionOver;

        if(isInteractionOver)
        {
            if (first)
            {
                first = false;
                GetComponent<DialogueTrigger>().init(dialoguePackage);
                GetComponent<DialogueTrigger>().StartDialogue();
            }
            if (GetComponent<DialogueTrigger>().dialogueManager.endOfConvo && first1)
            {
                first1 = false;
                GetComponent<DialogueTrigger>().dialogueManager.GetComponent<GameManager>().noMoreInteraction = true;
                GetComponent<DialogueTrigger>().dialogueManager.switchDialogueText();
                GetComponent<DialogueTrigger>().loadDialogue(1);
            }
            else if(first1 == false && GetComponent<DialogueTrigger>().dialogueManager.endOfConvo)
            {
                teleportDoll = true;
            }
        }
    }
}
