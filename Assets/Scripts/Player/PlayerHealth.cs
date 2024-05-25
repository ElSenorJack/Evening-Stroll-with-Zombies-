using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHP = 100f;
    [SerializeField] TextMeshProUGUI health;
    float HP;

    private void Start()
    {
        HP = maxHP;
    }

    private void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        health.text = HP.ToString();
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    public void RestoreHealth(float addHP)
    {
        HP += addHP;
        if (HP > maxHP) { HP = maxHP; }
    }
}
