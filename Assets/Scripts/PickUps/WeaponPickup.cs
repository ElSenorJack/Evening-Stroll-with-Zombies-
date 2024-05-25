using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject Weapons;
    public GameObject weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            weapon.transform.parent = Weapons.transform;
            Destroy(gameObject);
        }
    }
}
