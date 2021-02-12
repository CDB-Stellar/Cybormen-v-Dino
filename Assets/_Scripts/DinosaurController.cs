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
    private Transform currentTarget;
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        targetFinder = GetComponent<TargetFinder>();        
    }
    void Start()
    {
        village = GameObject.Find("Village").transform;
    }
    // Update is called once per frame
    void Update()
    {
        currentTarget = DetermineTarget();
        navAgent.stoppingDistance = FindStopingDistance();
        navAgent.SetDestination(currentTarget.position);
    }
    private void Attack()
    {
        /*TODO
         1. Attack target
         2. Send signal to do damage to target
         3. Check for higher priority target0

        Make whole script responsable determining target
         */
       
    }
    private Transform DetermineTarget()
    {
        Transform newTarget = village;
        // Loop through avalible targets
        for (int i = 0; i < targetFinder.visableTargets.Count; i++)
        {
            //loop thorugh avalible tags
            for (int k = targetPriority.Count - 1; k > -1 ; k--)
            {
                // check if target tag = priority tag;
                if (targetFinder.visableTargets[i].CompareTag(targetPriority[k]))
                {
                    // check if selected newTarget and potenial newTargets is closer
                    if (newTarget != null && newTarget.CompareTag(targetFinder.visableTargets[i].tag))
                    {
                        float dstNewTarget = Vector3.Distance(transform.position, newTarget.position);
                        float dstPontenialNewTarget = Vector3.Distance(transform.position, targetFinder.visableTargets[i].position);
                        if (dstNewTarget > dstPontenialNewTarget)
                        {
                            newTarget = targetFinder.visableTargets[i];
                        }
                    }
                    else
                    {
                        newTarget = targetFinder.visableTargets[i];
                    }
                    break;
                }
            }
        }
        return newTarget;
    }
    private float FindStopingDistance()
    {
        if (currentTarget == village)
            return stopDis;
        else
            return currentTarget.GetComponent<AIRadius>().radius + stopDis;
    }
}
