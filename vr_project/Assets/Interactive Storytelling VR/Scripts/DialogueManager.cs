using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text mirrorWorldDialogueText;
    public Queue<string> sentences;
    public bool endOfConvo;
    public bool isInteractionOver;
    [SerializeField] private GameObject[] dialogueUsers;
   public bool NextSentence;

    private void Update()
    {
        if (NextSentence)
        {
            NextSentence = false;
            DisplayNextSentence();
        }
    }
    void Start()
    {
        sentences = new Queue<string>();
        foreach (GameObject obj in dialogueUsers){
            obj.GetComponent<DialogueTrigger>().dialogueManager = this;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        endOfConvo = false;
       // nameText.text = dialogue._name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    void EndDialogue()
    {
        Debug.Log("End of convo");
        endOfConvo = true;
    }

    public void switchDialogueText()
    {
        dialogueText = mirrorWorldDialogueText;
    }
}
