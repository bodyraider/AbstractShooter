using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUILookAtYou : MonoBehaviour {
    // Use this for initialization
    GameObject lookpoint;
	void Start () {
        lookpoint = GameObject.FindGameObjectWithTag("LookPoint");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(lookpoint.transform);
	}
}
