using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] float explotionRange;
    [SerializeField] float explotionDistance;

    [SerializeField] float explotionForce;
    [SerializeField] float upwardsStrenght;
    private void Start()
    {
        foreach (RaycastHit hit in Physics.SphereCastAll(transform.position, explotionRange, Vector3.up, explotionDistance))
        {
            if (hit.transform.GetComponent<Rigidbody>() != null)
            {
                hit.transform.GetComponent<Rigidbody>().AddExplosionForce(explotionForce, transform.position, explotionRange, upwardsStrenght);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explotionRange);
    }
}
