using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPushUpBehaviour : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter com " + other.name);
        other.GetComponent<Rigidbody>().velocity = Vector3.up*10;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerEnter com " + other.name);
        other.GetComponent<Rigidbody>().velocity = Vector3.up * 10;
    }

}
