using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    //[SerializeField] GameObject hitHole;
    [SerializeField] GameObject hitSparks;
    [SerializeField] Ammo ammoSlot;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { Shoot();  }
    }

    private void Shoot()
    {
        if (ammoSlot.CurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            Raycasting();
            ammoSlot.ConsumeAmmo();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void Raycasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            ImpactHit(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void ImpactHit(RaycastHit hit)
    {
       GameObject impactSparks = Instantiate(hitSparks, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactSparks, 1);
       //GameObject impactHole = Instantiate(hitHole, hit.point, Quaternion.LookRotation(hit.normal));
       //Destroy(impactHole, 3);
    }
}
