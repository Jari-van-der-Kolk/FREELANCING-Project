using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Pickupable>() != null)
        {
            switch (collision.gameObject.GetComponent<Pickupable>().item)
            {
                case (Pickupable.itemSort.Ammo):
                    Debug.Log("Picked up Ammo");
                    break;
                case (Pickupable.itemSort.Health):
                    Debug.Log("Picked up Health");
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    
}
