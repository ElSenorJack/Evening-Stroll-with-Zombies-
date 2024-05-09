using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    Weapon weapon;
    
    [System.Serializable]
    public class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int CurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ConsumeAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount -= weapon.clipSize;
    }

    public void GrabAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots) 
        {
            if (slot.ammoType == ammoType)
            { 
                return slot;
            }
        }
        return null;
    }

}
