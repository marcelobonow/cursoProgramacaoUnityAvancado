using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickBehaviour : MonoBehaviour {

    [SerializeField]
    protected WalkToPointBehaviour walkBehaviour;
    [SerializeField]
    protected int LayerMaskIndex;

    protected int layerMask;

    private void Start()
    {
        layerMask = 1 << LayerMaskIndex;       
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
          
            if (Physics.Raycast(rayFromCamera, out rayHit,1000, layerMask))
                walkBehaviour.walkToPoint(rayHit.point);
        }
    }
}
