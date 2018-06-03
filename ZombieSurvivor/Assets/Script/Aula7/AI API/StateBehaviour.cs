using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class StateBehaviour : MonoBehaviour {

    abstract public void onEnter(StateMachineManager stateMachine);
    abstract public void onExit();

}
