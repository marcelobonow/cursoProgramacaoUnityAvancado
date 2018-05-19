using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRayCastBehaviour : MonoBehaviour {
    [SerializeField]
    protected float fireForce = 500;
    protected RaycastHit raycastHit;
   

    // Update is called once per frame
    void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            //Há 16 variações de sobrecargas para o método. Vamos utilizar a mais comum que passa origem, direção e um objeto para coletar as informações
            // O prefixo OUT indica que a variável é passada por referência, já que o retorno do método já possui o comportamento de retornar True ou False como resultado da colisão
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit))
            {
                raycastHit.rigidbody.AddForce(transform.forward * fireForce);
                Debug.Log("Distancia "+ raycastHit.distance);
                Debug.DrawRay(transform.position, transform.forward, Color.red,2);
                Debug.Break();
            }
        }
            
	}
}
