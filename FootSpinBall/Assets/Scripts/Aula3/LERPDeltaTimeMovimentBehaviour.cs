using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class LERPDeltaTimeMovimentBehaviour : MonoBehaviour {
    public Transform targetPosition;
    public float timeToComplete;

    protected Vector3 startPoistion;
    protected float deltaTimeCounter;
    
	// Use this for initialization
	void Start () {
        deltaTimeCounter = 0;
        startPoistion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTimeCounter += Time.deltaTime/ timeToComplete;
        Debug.Log(deltaTimeCounter);
        GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPoistion, targetPosition.position, deltaTimeCounter));

    }
}
