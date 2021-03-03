using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, Idamageable
{
    [SerializeField] private FloatReference startingHealth;

    public float currentHealth { get; private set; }
    public UiHealthbar healthbar;

    private void Start()
    {
        currentHealth = startingHealth.Value;
        healthbar.SetMaxHealth(currentHealth);
    }    
    public void GetDamaged(float damage)
    {
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
