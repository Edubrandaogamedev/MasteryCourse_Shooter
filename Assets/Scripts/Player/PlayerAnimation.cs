using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private float drawWeaponSpeed;
    [SerializeField] private float delayBeforeWeaponDown = 3;

    private Coroutine currentFadeRoutine;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentFadeRoutine != null)
                StopCoroutine(currentFadeRoutine);
            currentFadeRoutine = StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            currentFadeRoutine = StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeToShootingLayer()
    {
        
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;
        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime /drawWeaponSpeed;
            animator.SetLayerWeight(1,currentWeight);
            yield return null;
        }
        animator.SetLayerWeight(1,1);
    }
    private IEnumerator FadeFromShootingLayer()
    {
        yield return currentFadeRoutine;
        yield return new WaitForSeconds(delayBeforeWeaponDown);
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;
        while (currentWeight > 0)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime /drawWeaponSpeed;
            animator.SetLayerWeight(1,currentWeight);
            yield return null;
        }
        animator.SetLayerWeight(1,0);
    }
}
