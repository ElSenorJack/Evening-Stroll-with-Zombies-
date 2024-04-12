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
    [SerializeField] float shotsDelay = 0f;
    [SerializeField] int ammoConsume = 1;
    [SerializeField] AmmoType ammoType;
    [SerializeField] bool fullAuto = false;
    //[SerializeField] bool burstShot = false;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true; 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.CurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            Raycasting();
            ammoSlot.ConsumeAmmo(ammoType);
        }
        yield return new WaitForSeconds(shotsDelay);
        canShoot = true;

        if (Input.GetMouseButton(0) && fullAuto == true && canShoot == true)
        {
            StartCoroutine(Shoot());
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
