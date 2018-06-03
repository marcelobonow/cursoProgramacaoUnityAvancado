using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStateMachineManager : StateMachineManager {
    /* 0 NavigationMeshWalk State
     * 1 Shoot State
     */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            setActiveState(0);
        else if (Input.GetKey(KeyCode.W))
            setActiveState(1);
    }

}
