using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headshot : MonoBehaviour
{
    EnemyHealth health;

    public void Start()
    {
        health = GetComponentInParent<EnemyHealth>();
    }
    public void HeadDamage(float headshot)
    {
    BroadcastMessage("OnDamage", SendMessageOptions.DontRequireReceiver);
    health.hitPoints -= headshot;
        if (health.hitPoints <= 0)
        {
            health.Death();
        }
    }
}
