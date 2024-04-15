using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPick : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    int minAmmoAmount = 5;
    int maxAmmoAmount = 20;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var ammoAmount = Random.Range(minAmmoAmount, maxAmmoAmount);
            FindObjectOfType<Ammo>().GrabAmmo(ammoType, ammoAmount);
            Destroy(gameObject); 
        }
    }
}
