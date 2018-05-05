using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPhysics2DBehaviour : MonoBehaviour {

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        Vector3 newPoistion = new Vector2 (transform.position.x + horizontalDirection, transform.position.y + verticalDirection );
        GetComponent<Rigidbody2D>().MovePosition(newPoistion);
      
    }

}
