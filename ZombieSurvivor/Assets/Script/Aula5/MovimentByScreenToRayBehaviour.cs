using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimentByScreenToRayBehaviour : MonoBehaviour {
    private Vector3 targetPosition;
    protected Vector3 startPoistion;
    protected float deltaTimeCounter;
    protected float timeToComplete;
    protected bool walkingTo = false;

    public void walkToPoint(Vector3 target)
    {
        Debug.Log("Mandou caminhar para " + target);
        //Seta o estado para caminhando para um alvo. Isto será útil para testes durante o trajeto
        walkingTo = true;
        targetPosition = target;
        startPoistion = transform.position;
        //Calcula o tempo de duração do movimento tendo como base a distancia
        timeToComplete = Vector3.Distance(startPoistion, target)/3;
        //Faz o personagem olhar para o ponto alvo
        transform.LookAt(target);

    }

    private void Update()
    {
        if (walkingTo)
        {
            deltaTimeCounter += Time.deltaTime / timeToComplete;
            Debug.Log(deltaTimeCounter);
            GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPoistion, targetPosition, deltaTimeCounter));
            //Se chegou ao objetivo zera os valores e informa que não esta mais caminhando
            if (deltaTimeCounter >= 1)
            {
                deltaTimeCounter = 0;
                walkingTo = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromCamera =  Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(rayFromCamera, out rayHit, 1000))
                walkToPoint(rayHit.point);
        }
    }
}
