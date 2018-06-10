using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickStateBehaviour : StateBehaviour {

    [SerializeField]
    protected int LayerMaskIndex;
    protected int layerMask;
    [HideInInspector]
    public Vector3 targetPoint;

    StateMachineManager stateMachine;

    public override void onEnter(StateMachineManager stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void onExit()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        layerMask = 1 << LayerMaskIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(rayFromCamera, out rayHit, 1000, layerMask))
            {
                targetPoint = rayHit.point;
                stateMachine.stateDone(this);
            }
        }
    }

}
