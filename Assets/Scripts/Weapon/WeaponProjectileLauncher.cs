using System;
using UnityEngine;
public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private float raycastMaxDistance = 100f;
    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Vector3 direction = weapon.IsInAimMode ? GetDirection() : firePoint.forward;
        var projectile = projectilePrefab.Get<Projectile>(firePoint.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * movementSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300);
        if (Physics.Raycast(ray, out hitInfo, raycastMaxDistance, raycastLayerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();
        return direction;
    }
}