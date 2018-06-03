using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationMeshWalkToPointStateBehaviour : StateBehaviour
{
    [SerializeField]
    protected int LayerMaskIndex;

    protected int layerMask;

    protected Animator characterAnimator;
    protected NavMeshAgent navMeshAgent;
    protected bool isWalkingTo = false;

    private void Start()
    {
        //Note que é necessário popular esta variável já que não é possível chamar o Start da classe base
        characterAnimator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        layerMask =  1 << LayerMaskIndex;
    }

    protected void walkTo(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
        navMeshAgent.isStopped = false;
        isWalkingTo = true;
    }

    private void Update()
    {
        /*Perceba que este estado por si só poderia dividir em 2. Um que capta o click do mouse e outro que move-se até o local.
        Aqui poderia utilizar-se do conceito de máquinas de estado compostas. Porém, a complexidade fica muito elevada para o primeiro exemplo desta técnica.*/
        if (Input.GetMouseButtonDown(0) && !isWalkingTo)
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(rayFromCamera, out rayHit, 1000, layerMask))
                walkTo(rayHit.point);
        }else if (isWalkingTo && navMeshAgent.remainingDistance < 1)
            isWalkingTo = false;

        //Sincroniza o atributo com a variável do Animator
        characterAnimator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }

    public override void onExit()
    {
        navMeshAgent.isStopped = true;
        characterAnimator.SetFloat("Speed", 0);
        isWalkingTo = false;
    }

    public override void onEnter(StateMachineManager stateMachine)
    {
        //Do nothing on Enter
    }
}
