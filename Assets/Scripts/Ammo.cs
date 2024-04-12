using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int CurrentAmmo()
    {
        return ammoAmount;
    }

    public void ConsumeAmmo(int i)
    {
        ammoAmount -= i;
    }

}
