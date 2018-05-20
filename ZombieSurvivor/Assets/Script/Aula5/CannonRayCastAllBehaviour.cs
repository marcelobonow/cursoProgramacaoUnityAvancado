using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRayCastAllBehaviour : MonoBehaviour {
    [SerializeField]
    protected float fireForce = 500;
    [SerializeField]
    protected GameObject sparkPrefab;

    protected RaycastHit[] raycastHit;
   

    // Update is called once per frame
    void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            //O método RaycastAll tras uma lista de todos os objetos que colidiram com o raio
            raycastHit = Physics.RaycastAll(transform.position, transform.forward);
            if (raycastHit.Length>0)
                for (int i = 0; i < raycastHit.Length; i++)
                {
                    raycastHit[i].rigidbody.AddForce(transform.forward * fireForce);
                    GameObject spark = Instantiate(sparkPrefab);
                    spark.transform.position = raycastHit[i].point;
                    Destroy(spark, spark.GetComponent<ParticleSystem>().main.duration);
                }
        }
            
	}
}
