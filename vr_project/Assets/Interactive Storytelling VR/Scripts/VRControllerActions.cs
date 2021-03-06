using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class VRControllerActions : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean Decline;
    public SteamVR_Action_Boolean NextSentence;
    public bool sayYes;
    public bool sayNo;
    // a reference to the hand
    public SteamVR_Input_Sources handType;
    
    void Start()
    {
        Decline.AddOnStateUpListener(DeclineTrigger, handType);
        //Decline.AddOnStateDownListener(DeclineTrigger, handType);

        NextSentence.AddOnStateUpListener(NextSentenceTrigger, handType);
       // NextSentence.AddOnStateDownListener(NextSentenceTrigger, handType);
        
    }
    public void DeclineTrigger(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
       // Debug.Log("Declined");
                
    }
    public void NextSentenceTrigger(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
      
        //Debug.Log("NEXT SENTENCE");
        GetComponent<DialogueManager>().DisplayNextSentence();
      
    }

    void Update()
    {
        if (sayYes)
        {
            sayYes = false;
            GetComponent<NPCManager>().sendChoice(true);
        }
        if (sayNo)
        {
            GetComponent<NPCManager>().sendChoice(false);
            sayNo = false;
        }
    }
    
}