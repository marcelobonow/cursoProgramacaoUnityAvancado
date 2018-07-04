using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponDataObject : Object
{
    public string weaponName;
    public float radius = 5;
    public float damage = 5;
    public float ammo = 200;
    public GameObject particle;

    public WeaponDataObject(WeaponScript data)
    {
        weaponName = data.weaponName;
        radius = data.radius;
        damage = data.damage;
        ammo = data.ammo;
        particle = data.particle;
    }
}
