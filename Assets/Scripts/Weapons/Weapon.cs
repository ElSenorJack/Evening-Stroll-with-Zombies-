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
    [SerializeField] GameObject hitSparks;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float shotsDelay = 0f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] bool fullAuto = false;
    public int clipSize;
    int clip;
    public Animator animator;
    private bool isReloading = false;

    bool canShoot = true;

    private void Start()
    {
        clip = clipSize;
        
    }
    private void OnEnable()
    {
        canShoot = true;
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    public void Update()
    {
        if (isReloading) return;
        
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

        if (clip <= 0)
        {
            StartCoroutine(Reload());
            
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (clip > 0)
        {
            PlayMuzzleFlash();
            Raycasting();
            clip--;
        }
        yield return new WaitForSeconds(shotsDelay);
        canShoot = true;

        if (Input.GetMouseButton(0) && fullAuto == true && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Reloading", false);
        isReloading = false;
        clip += clipSize;
        FindObjectOfType<Ammo>().ConsumeAmmo(ammoType, clipSize);
        canShoot = true;
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
    }
}
