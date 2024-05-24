using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip enemyAttack;
    new AudioSource audio;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        audio = GetComponent<AudioSource>();
    }

    public void AttackEvent()
    {
        if (target == null) return;        
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamage();
        audio.PlayOneShot(enemyAttack);
    }
}
