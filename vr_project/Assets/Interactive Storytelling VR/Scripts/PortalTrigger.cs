using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{

    [SerializeField] private Material gateway;
    [SerializeField] private Material mirror;
    [SerializeField] private MeshRenderer target;
    [SerializeField] private Transform gatewayDestination;
    [SerializeField] private Transform theEndDestination;
    [SerializeField] private GameObject Ramp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Doll")
        {
            
            target.material = gateway;
            other.transform.parent.parent.position = gatewayDestination.position;
            //Debug.Log(other.transform.parent.gameObject.name);
            other.transform.gameObject.GetComponent<DollMover>().destination = theEndDestination;
            Ramp.SetActive(true);
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        target.material = mirror;
    }*/
}
