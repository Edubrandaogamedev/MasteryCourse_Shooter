using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthFillBar;
    [SerializeField] private TextMeshProUGUI healthText;
    private void Start()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnHealthChanged += HandleHit;
    }

    private void HandleHit(int currentHealth,int maxHealth)
    {
        healthText.text = $"{currentHealth}/{maxHealth}";
        healthFillBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
