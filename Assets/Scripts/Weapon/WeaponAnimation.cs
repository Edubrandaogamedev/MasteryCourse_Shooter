using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Weapon))]

public class WeaponAnimation : MonoBehaviour
{
    private Weapon weapon;
    private Animator animator;
    
    private readonly int Fire = Animator.StringToHash("Fire");

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        weapon.OnFire -= HandleWeaponFire;
    }

    private void Start()
    {
        weapon.OnFire += HandleWeaponFire;
    }

    private void HandleWeaponFire()
    {
        animator.SetTrigger(Fire);
    }
}
