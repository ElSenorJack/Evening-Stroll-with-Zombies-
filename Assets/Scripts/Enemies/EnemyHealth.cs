using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    { return isDead; }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }

}
    

