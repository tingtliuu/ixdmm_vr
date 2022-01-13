using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]

public class WorldNarritive : MonoBehaviour
{
    bool first = true;
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
        if (GetComponent<DialogueTrigger>().dialogueManager.isInteractionOver && first)
        {
            first = false;
            GetComponent<DialogueTrigger>().init(dialoguePackage);
            GetComponent<DialogueTrigger>().StartDialogue();
        }
    }
}
