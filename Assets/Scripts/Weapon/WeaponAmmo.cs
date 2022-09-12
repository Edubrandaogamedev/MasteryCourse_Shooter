using System;
using System.Collections;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    [SerializeField] private bool infiniteAmmo;
    [SerializeField] private int maxAmmo = 24;
    [SerializeField] private int maxAmmoPerClip = 6;
    [SerializeField] private float reloadSpeed = 0.2f;
    private int ammoInClip;
    private int ammoRemainingNotInClip;

    public event Action OnAmmoChanged = delegate { };
    public bool IsAmmoReady => ammoInClip > 0;
    protected override void Awake()
    {
        base.Awake();
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private IEnumerator Reload()
    {
        int ammoMissingFromClip = maxAmmoPerClip - ammoInClip;
        int ammoToMove = Mathf.Min(ammoMissingFromClip, ammoRemainingNotInClip);
        if (infiniteAmmo)
            ammoToMove = ammoMissingFromClip;
        while (ammoToMove > 0)
        {
            yield return new WaitForSeconds(reloadSpeed);
            ammoToMove--;
            ammoInClip++;
            ammoRemainingNotInClip--;
            OnAmmoChanged();
        }
    }
    private void RemoveAmmo()
    {
        ammoInClip--;
        OnAmmoChanged(); 
    }

    public string GetAmmoText()
    {
        if (infiniteAmmo)
            return $"{ammoInClip}/∞";
        else
            return $"{ammoInClip}/{ammoRemainingNotInClip}";
        
    }
}