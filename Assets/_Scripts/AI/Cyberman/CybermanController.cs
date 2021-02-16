using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CybermanController : MonoBehaviour
{
    [SerializeField] private float stopDis;
    public CybermanTask CurrentTask { get; private set; }    
    
    private const float WORK_SPEED = 1f;
    private Transform Village;
    private CybermanState currentState;
    private NavMeshAgent navAgent;

    float workTimer;

    enum CybermanState
    {
        Idle,
        MovingToTask,
        DoingTask,
        MovingToVillage
    }
    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        Village = GameObject.Find("Village").transform;
        currentState = CybermanState.Idle;
    }    
    private void Update()
    {
        switch (currentState)
        {
            case CybermanState.Idle:
                break;
            case CybermanState.MovingToTask:
                currentState = MoveToTask();
                break;
            case CybermanState.DoingTask:
                currentState = DoTask();
                break;
            case CybermanState.MovingToVillage:
                currentState = MoveToVillage();
                break;            
            default:
                break;
        }
    }
    private CybermanState MoveToTask()
    {
        if(CurrentTask.TaskLocation == null)
        {
            CurrentTask = null;
            return CybermanState.MovingToVillage;
        }
        navAgent.SetDestination(CurrentTask.TaskLocation.position);
        if (NavAgentArrived())
        {
            return CybermanState.DoingTask;
        }
        else
        {
            return CybermanState.MovingToTask;
        }
    }
    private CybermanState DoTask()
    {
        workTimer += WORK_SPEED * Time.deltaTime;
        if (CurrentTask.Work.DoWork(workTimer))
        {
            workTimer = 0f;
            return CybermanState.MovingToVillage;
        }
        else
        {            
            return CybermanState.DoingTask;
        }
    }
    private CybermanState MoveToVillage()
    {
        navAgent.SetDestination(Village.position);
        if (NavAgentArrived())
        {
            CurrentTask = null;
            return CybermanState.Idle;
        }
        else
        {
            return CybermanState.MovingToVillage;
        }
    }   
    private bool NavAgentArrived()
    {        
        return Vector3.Distance(navAgent.destination, transform.position) < navAgent.stoppingDistance;
    }
    public void AssignTask(CybermanTask newTask)
    {
        CurrentTask = newTask;
        currentState = CybermanState.MovingToTask;
    }


}
