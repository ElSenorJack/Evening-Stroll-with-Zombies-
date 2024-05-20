using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 10f;
    [SerializeField] TextMeshProUGUI health;

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        health.text = hitpoints.ToString();
    }

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
