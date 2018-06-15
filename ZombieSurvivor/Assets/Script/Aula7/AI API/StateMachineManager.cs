using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour {

    [SerializeField]
    protected StateBehaviour[] stateList;

    protected int _stateActiveIndex;
    private int stateLastIndex;

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
        stateLastIndex = _stateActiveIndex;
        _stateActiveIndex = activeState;
        stateList[_stateActiveIndex].enabled = true;
        stateList[_stateActiveIndex].onEnter(this);
    }

    public StateBehaviour getState(int stateIndex)
    {
        return stateList[stateIndex];
    }

    protected void desableState(int stateIndex)
    {
        stateList[stateIndex].onExit();
        stateList[stateIndex].enabled = false;
        stateLastIndex = stateIndex;
    }

    public virtual void stateDone(StateBehaviour state)
    {
        //avalia os atributos do estado e toma a decisão para que estado ir
    }
}
