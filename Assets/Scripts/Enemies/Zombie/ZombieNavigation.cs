using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private Transform playerTransform;
    private NavMeshPath path;

    private void Awake()
    {
        GetComponent<Health>().OnDied += HandleZombieDeath;
    }

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
    }

    private void Update()
    {
        var targetPosition = playerTransform.position;
        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if (foundPath)
        {
            Vector3 nextDestination = path.corners[1];
            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = Vector3.Normalize(new Vector3(directionToTarget.x, 0, directionToTarget.z));

            var desiredRotation = Quaternion.LookRotation(flatDirection);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);
            
            transform.rotation = finalRotation;
        }
    }

    private void HandleZombieDeath()
    {
        this.enabled = false;
    }
}
