using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] Transform Player;

    [SerializeField] float nearPlayerSpeed;
    [SerializeField] float wanderingSpeed;

    [SerializeField] float runningRange;
    NavMeshAgent navAgent;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        navAgent.SetDestination(Player.position);
        navAgent.speed = wanderingSpeed;
        foreach (RaycastHit hit in Physics.SphereCastAll(transform.position, runningRange, Vector3.up, runningRange))
        {
            if (hit.transform.GetComponent<PlayerTag>() != null)
            {
                navAgent.speed = nearPlayerSpeed;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, runningRange);
    }
}
