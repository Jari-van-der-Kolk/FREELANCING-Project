using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, Idamageable
{
   
    public void GetDamaged(float damage)
    {
        Destroy(gameObject);
    }
}
