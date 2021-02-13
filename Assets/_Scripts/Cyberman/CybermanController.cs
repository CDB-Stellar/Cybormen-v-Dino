using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CybermanController : MonoBehaviour
{
    const float WORK_SPEED = 1f;

    Transform Village;
    CybermanTask currentTask;
    CybermanState currentState;
    NavMeshAgent navAgent;

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
        navAgent.SetDestination(currentTask.TaskLocation.position);
        if (Vector3.Distance(navAgent.destination, transform.position) < 1f)
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
        if (currentTask.Work.DoWork(workTimer))
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
        if (navAgent.pathStatus == 0)
        {
            return CybermanState.Idle;
        }
        else
        {
            return CybermanState.MovingToVillage;
        }
    }
    public void AssignTask(CybermanTask newTask)
    {
        Debug.Log("Assigning Task");
        currentTask = newTask;
        currentState = CybermanState.MovingToTask;
    }

}
