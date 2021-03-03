using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, Idamageable
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
}
