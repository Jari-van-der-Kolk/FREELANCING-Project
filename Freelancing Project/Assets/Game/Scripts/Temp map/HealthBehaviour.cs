using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, Idamageable
{
   
    public void GetDamaged(int damage)
    {
        Destroy(gameObject);
    }
}
