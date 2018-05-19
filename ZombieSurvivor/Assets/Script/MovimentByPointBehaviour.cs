using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentByPointBehaviour : MonoBehaviour {
    private Vector3 targetPosition;
    protected Vector3 startPoistion;
    protected float deltaTimeCounter;
    protected float timeToComplete;
    protected bool walkingTo = false;

    public void walkToPoint(Vector3 target)
    {
        Debug.Log("Mandou caminhar para " + target);
        walkingTo = true;
        targetPosition = target;
        startPoistion = transform.position;
        timeToComplete = Vector3.Distance(startPoistion, target);
    }

    private void Update()
    {
        if (walkingTo)
        {
            deltaTimeCounter += Time.deltaTime / timeToComplete;
            Debug.Log(deltaTimeCounter);
            GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPoistion, targetPosition, deltaTimeCounter));
            if (deltaTimeCounter >= 1)
            {
                deltaTimeCounter = 0;
                walkingTo = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            walkToPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
           
        }
    }
}
