using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickNavMeshBehaviour : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
          
            if (Physics.Raycast(rayFromCamera, out rayHit,1000))
                GetComponent<NavMeshAgent>().SetDestination(rayHit.point);
        }
    }
}
