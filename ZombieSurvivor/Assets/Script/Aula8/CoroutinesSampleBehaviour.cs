using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesSampleBehaviour : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Routine());
        Debug.Log("Chamou Coroutine");
    }
    IEnumerator Routine()
    {
        Debug.Log("Iniciou Coroutine");
        for (float i = 0; i > 5; i++)
        {
            Debug.Log("Frame da Coroutine");
            yield return null;
        }
        Debug.Log("Terminou Coroutine");
    }
}
