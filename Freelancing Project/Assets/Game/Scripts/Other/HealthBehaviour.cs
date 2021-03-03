using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBehaviour : MonoBehaviour, Idamageable, IHealable
{
    [SerializeField] private FloatReference startingHealth;
    public TextMeshProUGUI UIHealth;

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
    void Update()
    {
        UIHealth.text = currentHealth.ToString();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth.Value);
    }
}
