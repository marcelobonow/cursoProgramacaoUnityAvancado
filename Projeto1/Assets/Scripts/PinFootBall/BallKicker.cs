using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKicker : MonoBehaviour {
    public GameObject ball;
    public float force=500;
    public float turnSpeed = 1;

    // Update is called once per frame
    void Update () {
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (horizontalAxis!=0)
            transform.Rotate(0, horizontalAxis* turnSpeed, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 forward = transform.forward;
            forward.y += 0.5f;
            ball.GetComponent<Rigidbody>().AddForce(forward * force);
        }
    }
}
