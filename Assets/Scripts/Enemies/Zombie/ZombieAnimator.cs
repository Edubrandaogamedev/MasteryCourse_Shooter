using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Zombie
{
    public class ZombieAnimator : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            GetComponent<Health>().OnTookHit += HandleHit;
            GetComponent<Health>().OnDied += HandleDeath;
            GetComponent<ZombieAttack>().OnAttack += HandleAttack;
        }

        private void HandleAttack()
        {
            animator.SetInteger("AttackId",Random.Range(1,4));
            animator.SetTrigger("Attack");
        }

        private void HandleHit()
        {
            animator.SetTrigger("Hit");
        }

        private void HandleDeath()
        {
            animator.SetTrigger("Die");
        }
    }
}