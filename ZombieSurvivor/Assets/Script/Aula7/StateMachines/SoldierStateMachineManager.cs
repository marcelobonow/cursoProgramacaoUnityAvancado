using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStateMachineManager : StateMachineManager {
    /* 0 NavigationMeshWalk State
     * 1 Shoot State
     */
    public static int NAVIGATION_MESH_WALK_STATE = 0;
    public static int SHOOT_STATE = 1;
    public static int THROW_STATE = 2;
    private int stateIndex=0;

    protected int getNextStateIndex()
    {
        //Verifica se está no final da lista. Se está, reinicia o index
        if (++stateIndex == stateList.Length)
            stateIndex = 0;
        return stateIndex;
    }
    // Update is called once per frame
    void Update()
    {
        //Avança para o próximo estado se a tecla Q for pressionada
        if (Input.GetKeyDown(KeyCode.Q))
            setActiveState(getNextStateIndex());
      
    }

}
