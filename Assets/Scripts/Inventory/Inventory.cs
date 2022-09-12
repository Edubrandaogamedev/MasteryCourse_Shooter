using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<Weapon> OnWeaponChanged = delegate {  };
    [SerializeField] private Weapon[] weapons;

    private void Awake()
    {
        SwitchToWeapon(weapons[0]);
    }

    private void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.HotKey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }

        OnWeaponChanged(weaponToSwitchTo);
    }
}
