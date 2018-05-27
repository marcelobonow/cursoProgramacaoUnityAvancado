using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPointBehaviour : MonoBehaviour {
    private Vector3 targetPosition;
    protected Vector3 startPoistion;
    protected float deltaTimeCounter;
    protected float timeToComplete;
    protected bool walkingTo = false;
    protected float speed=0;

    protected Animator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
    }

    public void walkToPoint(Vector3 target)
    {
        if (!walkingTo)
        {
            //Seta o estado para caminhando para um alvo. Isto será útil para testes durante o trajeto
            walkingTo = true;
            targetPosition = target;
            startPoistion = transform.position;
            //Calcula o tempo de duração do movimento tendo como base a distancia
            timeToComplete = Vector3.Distance(startPoistion, target) / 3;
            //Faz o personagem olhar para o ponto alvo
            transform.LookAt(target);
            deltaTimeCounter = 0;
        }
    }

    private void Update()
    {
        if (walkingTo)
        {
            deltaTimeCounter += Time.deltaTime / timeToComplete;
            Debug.Log(deltaTimeCounter);
            GetComponent<Rigidbody>().MovePosition(Vector3.Lerp(startPoistion, targetPosition, deltaTimeCounter));
            //Se chegou ao objetivo zera os valores e informa que não esta mais caminhando
            speed = 0.5f;
            if (deltaTimeCounter >= 1)
            {
                walkingTo = false;
                speed = 0;
            }
        }

        //Sincroniza o atributo com a variável do Animator
        characterAnimator.SetFloat("Speed", speed);
    }
}
