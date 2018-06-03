using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStateBehaviour : StateBehaviour
{
    [SerializeField]
    protected int LayerMaskIndex;
    protected int layerMask;

    private Animator characterAnimator;
    [SerializeField]
    private GameObject sparkPrefab;
 

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        layerMask = 1 << LayerMaskIndex;
    }

    public void shoot(Vector3 target)
    {
        characterAnimator.SetTrigger("Shoot");
        //RaycastHit raycastHit;
        //Ray ray = new Ray(transform.position, target - transform.position);
        target.y = 1.6f;
       // Physics.Raycast(ray,out raycastHit);
        transform.LookAt(target);
        GameObject spark = Instantiate(sparkPrefab);
        spark.transform.position = target;
        Destroy(spark, spark.GetComponent<ParticleSystem>().main.duration);
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(rayFromCamera, out rayHit, 1000))
                if(!rayHit.collider.CompareTag("Ground"))
                    shoot(rayHit.point);
        }
    }

    public override void onExit()
    {
       //Do nothing on Exit
    }

    public override void onEnter(StateMachineManager stateMachine)
    {
        //Do nothing on Enter
    }
}
