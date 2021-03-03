using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pickupable>() != null)
        {
            Debug.Log("working");
            switch (collision.gameObject.GetComponent<Pickupable>().item)
            {
                case (Pickupable.itemSort.Ammo):
                    Debug.Log("Picked up Ammo");
                    break;
                case (Pickupable.itemSort.Health):
                GetComponent<IHealable>().Heal(100);
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    
}
