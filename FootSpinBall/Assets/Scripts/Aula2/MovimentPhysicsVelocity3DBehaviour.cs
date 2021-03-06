﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPhysicsVelocity3DBehaviour : MonoBehaviour {
    public float speed;

    private void Start()
    {
        //Desliga o atributo para que o objetos possa receber velocidade.
        GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        if(horizontalDirection!=0 || verticalDirection!=0)
        {
            Debug.Log("tentou mover");
            Vector3 newPoistion = new Vector3(horizontalDirection,0, verticalDirection);
            GetComponent<Rigidbody>().velocity = newPoistion*speed;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu com " + collision.collider.name);
    }

}
