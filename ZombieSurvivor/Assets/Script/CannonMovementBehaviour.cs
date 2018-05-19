using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Exige que o objeto possua um component RigidBody
[RequireComponent(typeof(Rigidbody))]
public class CannonMovementBehaviour : MonoBehaviour {

    [SerializeField]
    protected float speed = 4; 
    
    // Update is called once per frame
	void Update () {
        float HDirection = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().velocity = new Vector3(HDirection*speed, 0, 0);
	}
}
