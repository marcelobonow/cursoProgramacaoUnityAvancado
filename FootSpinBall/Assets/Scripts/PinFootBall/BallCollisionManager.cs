using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionManager : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Informa o manager quando colidou com um outro objeto.
        PinFootBallManager.instance.onGoal(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Informa o manager quando colidou com um outro objeto.
        PinFootBallManager.instance.onGoal(collision.collider.gameObject);
    }
}
