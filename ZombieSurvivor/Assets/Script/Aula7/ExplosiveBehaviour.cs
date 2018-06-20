using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBehaviour : MonoBehaviour {

    [HideInInspector]
    public HitEventHandler hitHandler;
    [SerializeField]
    protected WeaponData weapon;
    [SerializeField]
    protected float timeToExplode=3;

    // Use this for initialization
    void Start () {
        Invoke("Explode", timeToExplode);
	}
	
	// Update is called once per frame
	public void Explode () {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, weapon.radius);

        for (int i = 0; i < hitObjects.Length; i++)
            hitHandler.OnAgentHited(weapon, hitObjects[i].gameObject, transform.position);

        GameObject explosion = Instantiate(weapon.particle);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    
    }
}
