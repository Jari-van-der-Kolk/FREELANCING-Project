using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, Idamageable, IHealable
{
    [SerializeField] private FloatReference startingHealth;

    public float currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = startingHealth.Value;
    }    
    public void GetDamaged(float damage)
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        Debug.Log(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth.Value);
    }
}
