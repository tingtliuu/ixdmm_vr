using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    Transform Host;
    public Transform Target;

	// Use this for initialization
	void Start () {
        Host = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Host.LookAt(Target);
	}
}
