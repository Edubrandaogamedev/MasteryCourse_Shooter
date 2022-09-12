using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticles : MonoBehaviour
{
    [SerializeField] private ProjectileImpact particlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        particlePrefab.Get<ProjectileImpact>(transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
    }
}
