using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagerBehaviour : MonoBehaviour {

    [SerializeField]
    Image[] iconList;

    [SerializeField]
    Image backgroundSelector;

    [SerializeField]
    StateMachineManager stateMachineManager;
    private void Update()
    {
        backgroundSelector.transform.position = iconList[stateMachineManager.StateActiveIndex].transform.position;
    }
}
