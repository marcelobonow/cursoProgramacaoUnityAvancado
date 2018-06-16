using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStateBehaviour : ShootingStateBehaviour {

    [SerializeField]
    protected GameObject projectilePrefab;
    [SerializeField]
    private float throwForce;

    public override void shoot(Vector3 target)
    {
        transform.LookAt(target);
        GameObject projectile = Instantiate(projectilePrefab);
        //Parte importante do código que propaga a injeção de dependencia para o objeto criado em tempo de execução
        projectile.GetComponent<ExplosiveBehaviour>().hitHandler = hitHandler;
        projectile.transform.position = transform.position;
        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
