using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurController : MonoBehaviour
{
    public Transform village;
    public List<string> targetPriority;
    public float stopDis;

    private NavMeshAgent navAgent;
    private TargetFinder targetFinder;
    private ObjectHealth health;
    private Transform currentTarget;
    private DinosaurState currentState;
  
    private enum DinosaurState
    {
        Attacking,
        Moving,
    }
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        targetFinder = GetComponent<TargetFinder>();
        health = GetComponent<ObjectHealth>();
    }
    void Start()
    {
        village = GameObject.Find("Village").transform;
        currentState = DinosaurState.Moving;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case DinosaurState.Attacking:
                break;
            case DinosaurState.Moving:
                currentState = Moving();
                break;
            default:
                break;
        }
    }
    
    private void Attack()
    {
        /*TODO
         1. Attack target
         2. Send signal to do damage to target
         3. Check for higher priority target0
        Also turn toward target

        Make whole script responsable determining target
         */       
    }
    private DinosaurState Moving()
    {
        currentTarget = DetermineTarget();
        navAgent.stoppingDistance = CalculateStoppingDistance();
        navAgent.SetDestination(currentTarget.position);         
        return DinosaurState.Moving;
    }
    private Transform DetermineTarget()
    {
        Transform newTarget = village;
        bool foundTarget = false;

        for (int i = 0; i < targetPriority.Count; i++)
        {
            if (foundTarget) return newTarget;
            for (int k = 0; k < targetFinder.visableTargets.Count; k++)
            {
                Transform potentialTarget = targetFinder.visableTargets[k];
                if (potentialTarget.CompareTag(targetPriority[i]))
                {
                    if (newTarget.CompareTag(potentialTarget.gameObject.tag))
                    { 
                        newTarget = FindCloser(potentialTarget, newTarget);
                    }
                    else
                    {
                        newTarget = potentialTarget;
                        foundTarget = true;
                    }
                }
            }
        }

        Debug.Log("New Target: " + newTarget.name);
        return newTarget;
    }
    private float CalculateStoppingDistance()
    {
        if (currentTarget == village)
            return stopDis;
        else
            return currentTarget.GetComponent<AIRadius>().radius + stopDis;
    }
    private Transform FindCloser(Transform t1, Transform t2)
    {
        if (Vector3.Distance(t1.position, transform.position) < Vector3.Distance(t2.position, transform.position)) return t1;
        else return t2;
    }
}
