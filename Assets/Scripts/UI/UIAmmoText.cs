using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmoText : MonoBehaviour
{
    private TextMeshProUGUI ammoText;
    private WeaponAmmo currentWeaponAmmo;
    private void Awake()
    {
        ammoText = GetComponent<TextMeshProUGUI>();
        Inventory.OnWeaponChanged += HandleWeaponChanged;
    }

    private void HandleWeaponChanged(Weapon weapon)
    {
        if (currentWeaponAmmo != null) currentWeaponAmmo.OnAmmoChanged -= HandleAmmoChanged;
        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();
        if (currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged += HandleAmmoChanged;
            HandleAmmoChanged();
        }
        else
        {
            ammoText.text = "Unlimited";
        }
    }

    private void HandleAmmoChanged()
    {
        ammoText.text = currentWeaponAmmo.GetAmmoText();
    }
}