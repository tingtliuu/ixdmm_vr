using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class LockToOrigin : MonoBehaviour
{
    GameObject OriginalLocation;
    //Transform newTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(name + ": " + transform.TransformPoint(GetComponent<LockToPoint>().transform.localPosition));
        OriginalLocation = new GameObject(name + "'s Original Transform");
        OriginalLocation.transform.position = transform.position;
        OriginalLocation.transform.eulerAngles = transform.eulerAngles;
        OriginalLocation.transform.SetParent(transform.parent);
        GetComponent<LockToPoint>().snapTo = OriginalLocation.transform;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(name + "'s World Position: " + newTransform.position);
    }

    public void Destroy()
    {
        Destroy(OriginalLocation);
    }
}
