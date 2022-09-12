using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Tooltip("How long the zombie waits after an attack to attack again")]
    [SerializeField] private float delayBetweenAttacks = 1.5f;
    [Tooltip("How far away the zombie can attack from")]
    [SerializeField] private float maximumAttackRange = 1.5f;

    [SerializeField] private float delayBetweenAnimationAndDamage = 0.25f;
    private Health playerHealth;
    private int damage = 1;
    private float attackTimer;
    public event Action OnAttack = delegate {};
    public bool CanAttack => attackTimer >= delayBetweenAttacks && Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (CanAttack)
        {
            attackTimer = 0;
            Attack();
        }
    }

    private void Attack()
    {
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }
}
