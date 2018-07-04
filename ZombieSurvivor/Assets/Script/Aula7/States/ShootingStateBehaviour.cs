using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStateBehaviour : StateBehaviour
{
    /*Este atributo será populado através de injeção de dependencia. 
    *É importante deixar o atributo oculto para o Inspector, pois o Unity não é capaz de mostrar atributos do tipo interface no editor
    */
    [HideInInspector]
    public HitEventHandler hitHandler;

    [SerializeField]
    protected WeaponScript weapon;

    protected WeaponDataObject weaponData;

    [SerializeField]
    protected int LayerMaskIndex;

    protected int layerMask;
    private Animator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        layerMask = 1 << LayerMaskIndex;
        weaponData = new WeaponDataObject(weapon);
        //weapon = ScriptableObject.Instantiate<WeaponScript>(weapon);

    }

    public virtual void shoot(Vector3 target)
    {
        characterAnimator.SetTrigger("Shoot");
        //Altera o Y do alvo para alinhar-se com a altura da arma
        target.y = 1.2f;
        //Força o personagem olhar para o local onde está atirando
        transform.LookAt(target);
        RaycastHit raycastHit;
        Ray ray = new Ray(transform.position, transform.forward);
        if(weapon.ammo-- > 0)
            if (Physics.Raycast(ray, out raycastHit))
                hitHandler.OnAgentHited(weaponData, raycastHit.collider.gameObject,raycastHit.point);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(rayFromCamera, out rayHit, 1000))
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
