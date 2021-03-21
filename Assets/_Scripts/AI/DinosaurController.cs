using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurController : MonoBehaviour
{
    public Transform village;
    public List<string> targetPriority;
    public float stopDis;
    public int damage;

    [Header("Damage Taken")]
    public int spearDamage;
    public int rocketDamage;
    public int rockDamage;

    private Animator anim;
    private NavMeshAgent navAgent;
    private TargetFinder targetFinder;
    private ObjectHealth health;
    private Transform currentTarget;
    private DinosaurState currentState;
  
    private enum DinosaurState
    {
        Attacking,
        Moving,
        Idle
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
                currentState = Attack();
                break;
            case DinosaurState.Moving:
                currentState = Moving();
                break;
            case DinosaurState.Idle:
                currentState = Idle();
                break;
            default:
                break;
        }
    }   
    private DinosaurState Attack()
    {
        if (currentTarget != null && currentTarget.CompareTag("Village"))
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking", false);
            return DinosaurState.Idle;
        }
        else if (currentTarget != null && NavAgentArrived())
        {
            navAgent.SetDestination(currentTarget.position);
            currentTarget.GetComponent<ObjectHealth>().TakeDamage(damage);
            return DinosaurState.Attacking;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            return DinosaurState.Moving;
        }        
    }
    private DinosaurState Moving()
    {
        currentTarget = DetermineTarget();
        navAgent.stoppingDistance = CalculateStoppingDistance();
        navAgent.SetDestination(currentTarget.position);
        if (NavAgentArrived())
        {
            anim.SetBool("isAttacking", true);
            return DinosaurState.Attacking;
        }
        else
        {            
            return DinosaurState.Moving;
        }    
    }
    private DinosaurState Idle()
    {
        currentTarget = DetermineTarget();
        if (!currentTarget.CompareTag("Village"))
        {
            anim.SetBool("isIdle", false);
            return DinosaurState.Moving;
        }
        else
        {
            return DinosaurState.Idle;
        }
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
                if (potentialTarget != null && potentialTarget.CompareTag(targetPriority[i]))
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
        return newTarget;
    }
    private bool NavAgentArrived()
    {
        if (navAgent.destination != null)
        {
            return Vector3.Distance(navAgent.destination, transform.position) < navAgent.stoppingDistance;
        }
        else
        {
            return false;
        }
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
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Spear"))        
            health.TakeDamage(spearDamage);
        else if (collision.gameObject.CompareTag("Rocket"))
            health.TakeDamage(rocketDamage);
        else if (collision.gameObject.CompareTag("RockShell"))
            health.TakeDamage(rockDamage);
    }
}
