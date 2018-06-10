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
    }

    protected Vector3 getNextPoint()
    {
        //Verifica se está no final da lista. Se está, reinicia o index
        if (++wayPointIndex == wayPoints.Length)
            wayPointIndex = 0;
        return wayPoints[wayPointIndex].position;
    }

    IEnumerator script()
    {
        StartCoroutine(moveToPoint(getNextPoint()));
        //StartCoroutine(jump());
        //StartCoroutine(moveToPoint(getNextPoint()));

        yield return null;
    }

    IEnumerator moveToPoint(Vector3 targetPoint)
    {
        Debug.Log("MoveToPoint " + Vector3.Distance(transform.position, targetPoint));
        Vector3 direction = Vector3.Normalize(wayPoints[wayPointIndex].position - transform.position);

        while (Vector3.Distance(transform.position, targetPoint) > 1)
        {
            Debug.Log("MoveToPoint " + direction);
            rigidbody.AddForce(direction * speed);
            yield return new WaitForSeconds(2);
        }

        yield return null;
        StartCoroutine(jump());
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
        StartCoroutine(moveToPoint(getNextPoint()));
    }
}
