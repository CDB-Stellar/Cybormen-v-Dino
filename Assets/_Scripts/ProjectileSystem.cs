using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    public bool towerActive = false; //activate tower when finished building
    [Header("0=Cannon, 1=Spear, 2=Rocket")]
    [SerializeField] private int towerType; //to turn on/off animation stuff [0=Cannon, 1=Spear, 2=Rocket]
    [SerializeField] private GameObject projectilePrefab; //what to shoot
    [SerializeField] private Transform shootFrom; //where projectile shoots from
    [SerializeField] private float fireRate = 1f; //how often to shoot (in seconds)
    [SerializeField] private float moveSpeed = 15f; //how fast projectile goes
    
    [SerializeField] private GameObject rotationBit; //Tower_Cyberman or turret
    private Animator anim; //Tower_Cyberman animator
    public List<string> targetPriority; //list of enemies

    private TargetFinder targetFinder; //use the target finder
    private Transform currentTarget;
    private float nextSpawnTime; //for fire rate, so it doesn't spawn infinitely


    void Awake()
    {
        if (towerType != 0)
            anim = rotationBit.GetComponent<Animator>(); //for Tower_Cyberman

        targetFinder = GetComponent<TargetFinder>();
        nextSpawnTime += Time.time + fireRate;
    }
    void Update()
    {
        if (towerActive)
        {
            //currentTarget = testTarget.transform; //for testing
            currentTarget = DetermineTarget();

            if (!currentTarget.CompareTag("Tower")) //if targeting tower do nothing
            {
                // Rotate Cyberman / Turret
                Vector3 lookDir = (currentTarget.position - transform.position);
                rotationBit.transform.rotation = Quaternion.LookRotation(lookDir);

                //Debug.Log("Shoot--");
                if (Time.time > nextSpawnTime) //only instantiate new projectile every fireRate increment
                {
                    if (towerType == 1)
                        anim.Play("Base Layer.Cyberman_Throw", 0, 0.95f); // Play the Cyberman's throw animation
                    else if (towerType == 2)
                        anim.Play("Base Layer.Cyberman_Shoot", 0, 0.25f); // Play the Cyberman's shoot animation

                    // Instantiate at the shootFrom position and zero rotation.
                    Instantiate(projectilePrefab,
                        new Vector3(shootFrom.position.x, shootFrom.position.y, shootFrom.position.z), Quaternion.identity);

                    // Only shoot projectile after animation plays??
                    //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Cyberman_Throw"))
                    //{
                    //    // Instantiate at the shootFrom position and zero rotation.
                    //    Instantiate(projectilePrefab,
                    //        new Vector3(shootFrom.position.x, shootFrom.position.y, shootFrom.position.z), Quaternion.identity);
                    //}

                    nextSpawnTime += fireRate;
                }

                Vector3 shootDir = (currentTarget.position - transform.position).normalized;
                projectilePrefab.GetComponent<Projectile>().Setup(shootDir, moveSpeed, currentTarget); //add force to the projectile
            }
        }
    }

    public void ActivateTower()
    {
        towerActive = true;
    }

    /**_________________________USING TargetFinder_________________________**/
    //the targets must have a collider!
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
