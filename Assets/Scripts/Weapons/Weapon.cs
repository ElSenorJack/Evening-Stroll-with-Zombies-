using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] AudioClip shots;
    [SerializeField] AudioClip reload;
    new AudioSource audio;
    float headshot;
    public int clipSize;
    int clip;
    public Animator animator;
    private bool isReloading = false;

    bool canShoot = true;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        clip = clipSize;
        headshot = damage * 2;
    }
    private void OnEnable()
    {
        canShoot = true;
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    public void Update()
    {
        DisplayAmmo();
        if (isReloading) return;
        
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

        if (clip <= 0 && ammoSlot.CurrentAmmo(ammoType) > 0)
        {
            StartCoroutine(Reload());           
        }

        if (Input.GetKeyDown(KeyCode.R) && clip < clipSize && ammoSlot.CurrentAmmo(ammoType) > 0) 
        { 
            StartCoroutine(Reload());
        }
    }

    public void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.CurrentAmmo(ammoType);
        ammoText.text = clip + " 1 " + currentAmmo.ToString(); //1 looks like "/" with the font used
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (clip > 0)
        {
            audio.PlayOneShot(shots);
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
        var clipMissing = clipSize - clip;
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(2f);
        if (clipMissing < ammoSlot.CurrentAmmo(ammoType))
        {
            clip += clipMissing;
            FindObjectOfType<Ammo>().ConsumeAmmo(ammoType, clipMissing);
        }
        else
        {
            clip += ammoSlot.CurrentAmmo(ammoType);
            FindObjectOfType<Ammo>().ConsumeAmmo(ammoType, ammoSlot.CurrentAmmo(ammoType));
        }
        audio.PlayOneShot(reload);
        animator.SetBool("Reloading", false);
        isReloading = false;
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
            Headshot head = hit.transform.GetComponent<Headshot>();
            if (target != null) { target.TakeDamage(damage); }

            if (head != null) head.HeadDamage(headshot);
        }
        else { return; }
    }

    private void ImpactHit(RaycastHit hit)
    {
       GameObject impactSparks = Instantiate(hitSparks, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactSparks, 1);
    }
}
