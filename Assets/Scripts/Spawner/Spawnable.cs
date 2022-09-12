using UnityEngine;

public class Spawnable : PooledMonoBehaviour
{
    [SerializeField] private float returnToPoolDelay = 10;

    private void Start()
    {
        if (GetComponent<Health>() != null)
            GetComponent<Health>().OnDied += () => ReturnToPool(returnToPoolDelay);
    }
}