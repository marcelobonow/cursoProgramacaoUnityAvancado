using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesSampleWaitForSecondBehaviour : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(RoutineForSeconds());
        Debug.Log("Chamou Coroutine");
    }
    IEnumerator RoutineForSeconds()
    {
        Debug.Log("Iniciou Coroutine");
        for (float i = 0; i < 5; i++)
        {
            Debug.Log("Frame da Coroutine de 2 seg " +i);
            yield return new WaitForSeconds(2);
        }
        Debug.Log("Terminou Coroutine");
    }
}
