using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CrateBehaviour : MonoBehaviour {

    [SerializeField]
    protected Transform[] wayPoints;

    [SerializeField]
    protected float speed;

    protected int wayPointIndex = -1;

    protected Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(script());
        //nada
    }

    IEnumerator script()
    {
        yield return StartCoroutine(moveToPoint(getNextPoint()));
        yield return StartCoroutine(jump());
        yield return StartCoroutine(moveToPoint(getNextPoint()));
        yield return StartCoroutine(jump());
    }

    IEnumerator moveToPoint(Vector3 targetPoint)
    {
        Vector3 direction = Vector3.Normalize(targetPoint - transform.position);

        while (Vector3.Distance(transform.position, targetPoint) > 1)
        {
            rigidbody.AddForce(direction * speed);
            yield return new WaitForSeconds(2);
        }

        yield return null;
    }

    IEnumerator jump()
    {
        Debug.Log("jump ");
        for (float i = 0; i < 1; i += 0.1f)
        {
            transform.localScale = new Vector3(1, Mathf.Lerp(1, 0.5f, i), 1);
            yield return null;
        }

        transform.localScale = Vector3.one;
        rigidbody.AddForce(Vector3.up * speed);
        yield return new WaitForSeconds(4);
    }

    protected Vector3 getNextPoint()
    {
        //Verifica se está no final da lista. Se está, reinicia o index
        if (++wayPointIndex == wayPoints.Length)
            wayPointIndex = 0;
        return wayPoints[wayPointIndex].position;
    }
}
