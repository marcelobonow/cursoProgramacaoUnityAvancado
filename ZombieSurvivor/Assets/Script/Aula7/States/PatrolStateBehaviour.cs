using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateBehaviour : WalkToOnMeshStateBehaviour {

    [SerializeField]
    protected Transform[] wayPoints;
    protected int wayPointIndex=-1;

    override public void onEnter(StateMachineManager machine)
    {
        walkTo(getNextPoint());
    }

    protected Vector3 getNextPoint()
    {
        //Verifica se está no final da lista. Se está, reinicia o index
        if (++wayPointIndex == wayPoints.Length)
            wayPointIndex = 0;
        return wayPoints[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update () {
        //Ao finalizar um path, já dispara o próximo. 
        if (isWalkingTo && navMeshAgent.remainingDistance < 1)
            navMeshAgent.SetDestination(getNextPoint());
    }
 }
