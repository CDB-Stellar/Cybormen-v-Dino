using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; //what to shoot
    [SerializeField] private Transform shootFrom; //where projectile shoots from
    [SerializeField] private float fireRate = 1f; //how often to shoot (in seconds)
    [SerializeField] private float moveSpeed = 15f; //how fast projectile goes
    public List<string> targetPriority; //list of enemies

    private TargetFinder targetFinder; //use the target finder
    private Transform currentTarget;
    private float nextSpawnTime; //for fire rate, so it doesn't spawn infinitely


    void Awake()
    {
        targetFinder = GetComponent<TargetFinder>();
        nextSpawnTime += Time.time + fireRate;
    }
    void Update()
    {
        //currentTarget = testTarget.transform; //for testing
        currentTarget = DetermineTarget();

        if (!currentTarget.CompareTag("Tower")) //if targeting tower do nothing
        {
            Debug.Log("Shoot--");
            if (Time.time > nextSpawnTime) //only instantiate new projectile every fireRate increment
            {
                // Instantiate at the shootFrom position and zero rotation.
                Instantiate(projectilePrefab, new Vector3(shootFrom.position.x, shootFrom.position.y, shootFrom.position.z), Quaternion.identity);

                nextSpawnTime += fireRate;
            }

            Vector3 shootDir = (currentTarget.position - transform.position).normalized;
            projectilePrefab.GetComponent<Projectile>().Setup(shootDir, moveSpeed); //add force to the projectile
        }
    }

    /**_________________________USING TargetFinder_________________________**/
    private Transform DetermineTarget()
    {
        Transform newTarget = shootFrom.transform; //default target is the tower
        bool foundTarget = false;

        for (int i = 0; i < targetPriority.Count; i++)
        {
            if (foundTarget)
                return newTarget;
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

        Debug.Log("New Tower Target: " + newTarget.tag);
        return newTarget;
    }
    private Transform FindCloser(Transform t1, Transform t2)
    {
        if (Vector3.Distance(t1.position, transform.position) < Vector3.Distance(t2.position, transform.position)) return t1;
        else return t2;
    }
}
