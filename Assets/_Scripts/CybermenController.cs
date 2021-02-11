using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CybermenController : MonoBehaviour
{
    public bool IsBusy { get; }

    private NavMeshAgent navAgent;
    private Transform currentTarget;
    private CybermanState currentState;
    enum CybermanState
    {
        Idle,
        MovingToJob,
        DoingJob,
        MovingToVillage
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = CybermanState.Idle;        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case CybermanState.Idle:
                break;
            case CybermanState.MovingToJob:
                MoveToJob();
                break;
            case CybermanState.DoingJob:
                break;
            case CybermanState.MovingToVillage:
                MoveToVillage();
                break;
            default:
                break;
        }
    }
    private CybermanState MoveToVillage()
    {
        navAgent.SetDestination(currentTarget.position);

        if (navAgent.pathStatus == 0 && IsBusy) return CybermanState.Idle;
        else return CybermanState.MovingToVillage;
    }
    private CybermanState MoveToJob()
    {
        navAgent.SetDestination(currentTarget.position);
        if (navAgent.pathStatus == 0) return CybermanState.DoingJob;
        else return CybermanState.MovingToJob; 
        
    }
    private CybermanState DoJob()
    {
        return CybermanState.DoingJob;
    }
    private void UnloadInventory()
    {

    }
}
