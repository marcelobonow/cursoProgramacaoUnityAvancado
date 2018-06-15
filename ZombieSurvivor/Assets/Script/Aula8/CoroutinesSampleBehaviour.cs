using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesSampleBehaviour : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Routine());
        Debug.Log("Linha pos Coroutine 1");
        Debug.Log("Linha pos Coroutine 2");
        Debug.Log("Linha pos Coroutine 3");
    }
    IEnumerator Routine()
    {
        Debug.Log("Iniciou Coroutine");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Frame da Coroutine " +i);
            yield return null;
        }
        Debug.Log("Terminou Coroutine");
    }
}
