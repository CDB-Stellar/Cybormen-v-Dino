using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurController : MonoBehaviour
{
    public Transform targetDestination;

    private NavMeshAgent navAgent;
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(targetDestination.position);
    }
    private void Attack()
    {
        /*TODO
         1. Attack target
         2. Send signal to do damage to target
         3. Check for higher priority target0

        Make whole script responsable for finding targets
         */
       
    }
}
