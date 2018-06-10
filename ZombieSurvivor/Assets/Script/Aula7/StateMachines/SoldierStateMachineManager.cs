using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStateMachineManager : StateMachineManager {
    /* 0 NavigationMeshWalk State
     * 1 Shoot State
     */
    public static int NAVIGATION_MESH_WALK_STATE = 0;
    public static int SHOOT_STATE = 1;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            setActiveState(0);
        else if (Input.GetKey(KeyCode.W))
            setActiveState(1);
    }

}
