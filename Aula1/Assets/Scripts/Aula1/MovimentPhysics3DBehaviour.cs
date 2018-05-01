using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPhysics3DBehaviour : MonoBehaviour {

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        if(horizontalDirection!=0 || verticalDirection!=0)
        {
            Vector3 newPoistion = new Vector3(transform.position.x + horizontalDirection, transform.position.y, transform.position.z + verticalDirection);
            GetComponent<Rigidbody>().MovePosition(newPoistion);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com " + collision.collider.name);
    }

}
