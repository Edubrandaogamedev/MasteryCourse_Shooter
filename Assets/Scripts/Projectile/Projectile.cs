using System;
using UnityEngine;

public class Projectile : PooledMonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }
}
