using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacterBehaviourState : WalkToOnMeshStateBehaviour {

    public Transform targetCharacter;

    public override void onEnter(StateMachineManager stateMachine)
    {
        walkTo(targetCharacter.position);
    }

    private void Update()
    {
        navMeshAgent.SetDestination(targetCharacter.position);
    }
}
