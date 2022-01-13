using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class AttachLimb : MonoBehaviour
{
    public GameObject[] missingLimbs;
    bool isLimbReceived;
    [SerializeField] GameObject GameManager;
    List<GameObject> missingLimbsList;
    // Start is called before the first frame update
    void Start()
    {
        missingLimbsList = new List<GameObject>();
        foreach (GameObject limb in missingLimbs)
        {
            missingLimbsList.Add(limb);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (missingLimbsList.Count == 0 || other.transform.parent.tag != "Player") return;       
        GameObject offeredLimb = other.transform.gameObject;
        

        for (int i = 0; i < missingLimbsList.Count; i++) {
            if (offeredLimb.CompareTag(missingLimbsList[i].tag))
            {
                missingLimbsList[i].GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
                missingLimbsList.Remove(missingLimbsList[i]);
                offeredLimb.GetComponent<LockToOrigin>().Destroy();
                offeredLimb.GetComponent<LockToPoint>().enabled = false;
                Destroy(offeredLimb);
                GameManager.GetComponent<NPCManager>().sendChoice(true);
            }
              
        }
        
    } 
}
