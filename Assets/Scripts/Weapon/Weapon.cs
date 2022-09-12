using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private KeyCode weaponHotKey;
    [SerializeField] private float fireDelay = 0.25f;
    private WeaponAmmo _ammo;

    private float fireTimer;
    private bool CanFire => (_ammo == null || _ammo.IsAmmoReady) && fireTimer >= fireDelay;

    public KeyCode HotKey => weaponHotKey;
    public bool IsInAimMode => !Input.GetMouseButton(1);
    
    public event Action OnFire = delegate {};

    private void Awake()
    {
        _ammo = GetComponent<WeaponAmmo>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (CanFire)
                Fire();
        }
    }

    private void Fire()
    {
        fireTimer = 0;
        OnFire();
    }

}
