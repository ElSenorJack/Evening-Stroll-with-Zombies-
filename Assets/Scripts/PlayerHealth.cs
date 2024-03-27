using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 10f;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            Debug.Log("Oh no, you pooped it! you poop");
            //Destroy(gameObject);
        }
    }
}
