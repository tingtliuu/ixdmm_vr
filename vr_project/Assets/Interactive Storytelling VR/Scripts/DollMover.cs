using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollMover : MonoBehaviour
{
    public bool isActive, isTriggered;
    public float movementSpeed = .4f;
    public Transform destination;   //First Destination
    [SerializeField] private Transform callibrationPos; //Second Destination
    [SerializeField] private Transform mirror; //Final Destination

    private Transform doll;
    private bool isAtCallibrationPosition;

    private void Start()
    {
        doll = transform.parent.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            destination = callibrationPos;
        }
    }

    private void OnEnable()
    {
        isActive = enabled;
        
    }
    private void Update()
    {
        if (isTriggered) destination = callibrationPos;
        
            if (!isAtCallibrationPosition)
            {
                float distanceToTarget = Vector3.Distance(doll.position, callibrationPos.position);
                if (distanceToTarget < 0.1f)
                {
                    destination = mirror;
                    movementSpeed = 0.4f;
                    isAtCallibrationPosition = true;
                    isTriggered = false;
                }
            }
        
       
        transform.parent.parent.position = Vector3.MoveTowards(doll.position, destination.position, movementSpeed * Time.deltaTime);
        
    }
}
