using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()  { return isDead; }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;
    }

}
    

