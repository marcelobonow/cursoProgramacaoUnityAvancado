using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class LERPDeltaTimeGoalKeeperMovimentBehaviour : MonoBehaviour {
    public Transform[] targetPosition = new Transform[2];
    public float timeToComplete;

    private bool indexTargetPositionList =false;

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
         GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPoistion, targetPosition[Convert.ToInt32(indexTargetPositionList)].position, deltaTimeCounter));
        Debug.Log("DElta Time " + deltaTimeCounter);
        if (deltaTimeCounter>=1)
        {
            //inverte o bool par pergar o outro index
            indexTargetPositionList = !indexTargetPositionList;
            //Zera o acumulador de tempo
            deltaTimeCounter = 0;
            //Renova a posição inicial
            startPoistion = transform.position;
        }
    }
}
