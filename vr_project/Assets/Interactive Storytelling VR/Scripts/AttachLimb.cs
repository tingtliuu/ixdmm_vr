using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class AttachLimb : MonoBehaviour
{
    public GameObject[] missingLimbs;
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
       
        if (missingLimbsList.Count == 0) return;

        GameObject offeredLimb = other.transform.parent.gameObject;

        for (int i = 0; i < missingLimbsList.Count; i++) {

            //Debug.Log(missingLimbsList[i].name);
                if (offeredLimb.CompareTag(missingLimbsList[i].tag))
                {
                missingLimbsList[i].GetComponentInChildren<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
                missingLimbsList.Remove(missingLimbsList[i]);
                offeredLimb.GetComponent<LockToOrigin>().Destroy();
                offeredLimb.GetComponent<LockToPoint>().enabled = false;
                Destroy(offeredLimb);
                }
              
        }
        
    } 
}
