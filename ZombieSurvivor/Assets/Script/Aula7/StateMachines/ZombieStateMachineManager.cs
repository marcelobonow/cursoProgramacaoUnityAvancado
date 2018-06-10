using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachineManager : StateMachineManager {
    /*
     * 0 - Patrol Behaviour
     * 1 - Follow Player
     * 2 - Attack Player
    */
    
    protected static int PATROL_STATE = 0;
    protected static int FOLLOW_STATE = 1;
    protected static int ATTACK_STATE = 2;

    [SerializeField]
    protected float distanceLineSight;
    [SerializeField]
    protected float distanceToAttack;
    [SerializeField]
    protected GameObject enemy;
    [SerializeField]
    protected SpriteRenderer colorCircle;
    [SerializeField]
    protected Color[] colorStateList;

    protected override void Start()
    {
        base.Start();

    }

    private void Update()
    {
        if (GetComponent<AgentData>().life <= 0)
            desableState(StateActiveIndex);
        else if (Vector3.Distance(transform.position, enemy.transform.position) < distanceLineSight && Vector3.Distance(transform.position, enemy.transform.position) > distanceToAttack && _stateActiveIndex != FOLLOW_STATE)
            setActiveState(FOLLOW_STATE);
        else if (Vector3.Distance(transform.position, enemy.transform.position) < distanceToAttack && _stateActiveIndex != ATTACK_STATE)
            setActiveState(ATTACK_STATE);
        else if (Vector3.Distance(transform.position, enemy.transform.position) > distanceLineSight && _stateActiveIndex != PATROL_STATE)
            setActiveState(PATROL_STATE);
        colorCircle.color = colorStateList[StateActiveIndex];
    }


}
