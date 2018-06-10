using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToOnMeshStateBehaviour : StateBehaviour {
    protected Animator characterAnimator;
    protected NavMeshAgent navMeshAgent;
    protected bool isWalkingTo = false;

    virtual protected void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected void walkTo(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
        navMeshAgent.isStopped = false;
        isWalkingTo = true;
        characterAnimator.SetBool("Walk", true);
    }

    public override void onExit()
    {
        navMeshAgent.isStopped = true;
        characterAnimator.SetBool("Walk", false);
    }

    public override void onEnter(StateMachineManager stateMachine)
    {
        //throw new System.NotImplementedException();
    }
}
