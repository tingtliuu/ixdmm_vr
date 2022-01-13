using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    List<Dialogue> dialoguePackage;
    [HideInInspector] public DialogueManager dialogueManager;

    public bool nextSentence;
    //private DialoguePackage dialoguePackage;
    // Start is called before the first frame update

    public void init(List<Dialogue> dialoguePackage)
    {
        this.dialoguePackage = dialoguePackage;
    }

    
    private void Start()
    {
        dialoguePackage = new List<Dialogue>();        
    }


    public void StartDialogue()
    {
        if (dialoguePackage.Count != 0)
            loadDialogue(0);
    }

    public void loadDialogue(int dialogueNumber)
    {
        if (dialoguePackage.Count != 0)
            dialogueManager.StartDialogue(dialoguePackage[dialogueNumber]);
    }
}
