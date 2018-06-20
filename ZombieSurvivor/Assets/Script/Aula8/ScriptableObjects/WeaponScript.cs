using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName ="WeaponScript")]
public class WeaponScript : ScriptableObject {

    public string weaponName;
    public float radius = 5;
    public float damage = 5;
    public float ammo = 200;
    public GameObject particle;
}
