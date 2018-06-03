using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour {

    [SerializeField]
    protected StateBehaviour[] stateList;

    protected int _stateActiveIndex;

    public int StateActiveIndex
    {
        get
        {
            return _stateActiveIndex;
        }
    }

    protected virtual void Start()
    {
        //Percorre todas os estados atriundo a máquina a si
        for (int i = 0; i < stateList.Length; i++)
            stateList[i].enabled = false;
        setActiveState(0);
    }

    protected void setActiveState(int activeState)
    {
        stateList[_stateActiveIndex].onExit();
        stateList[_stateActiveIndex].enabled = false;
        _stateActiveIndex = activeState;
        stateList[_stateActiveIndex].enabled = true;
        stateList[_stateActiveIndex].onEnter(this);
    }

    public virtual void stateDone(StateBehaviour state)
    {
        //avalia os atributos do estado e toma a decisão para que estado ir
    }
}
