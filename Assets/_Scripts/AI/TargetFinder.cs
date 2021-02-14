using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [HideInInspector]
    public List<Transform> visableTargets = new List<Transform>();
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float viewRadius;

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    private void FindVisibleTargets()
    {
        visableTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            float dstToTarget = Vector3.Distance(transform.position, target.position);
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
            {
                visableTargets.Add(target);
            }
        }

    }
}
