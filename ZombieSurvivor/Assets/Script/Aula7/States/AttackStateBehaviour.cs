using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackStateBehaviour : StateBehaviour {

    [SerializeField]
    protected float ItervalAttack = 2;
    [SerializeField]
    protected GameObject enemy;

    Animator animatorComponent;
    NavMeshAgent navMeshAgent;
    

    public override void onEnter(StateMachineManager stateMachine)
    {
        Invoke("Attack", ItervalAttack);
    }

    protected void Attack()
    {
        animatorComponent.SetTrigger("Attack");
        transform.LookAt(enemy.transform);
        Invoke("Attack", ItervalAttack);
    }

    public override void onExit()
    {
        //
    }

    // Use this for initialization
    void Start () {
        animatorComponent = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	

}
