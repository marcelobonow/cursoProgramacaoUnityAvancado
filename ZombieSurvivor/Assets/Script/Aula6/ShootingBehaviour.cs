using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour {

    Animator characterAnimator;

	// Use this for initialization
	void Start () {
        characterAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2"))
            characterAnimator.SetBool("Shoot", true);
        else if((Input.GetButtonUp("Fire2")))
            characterAnimator.SetBool("Shoot", false);
    }
}
