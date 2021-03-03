using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CybermanController : MonoBehaviour
{
    [SerializeField] private float stopDis;
    public CybermanTask CurrentTask { get; private set; }    
    
    private const float WORK_SPEED = 1f;
    private CybermanState currentState;

    private Transform Village;
    private NavMeshAgent navAgent;
    private Animator anim;

    private float workTimer;

    enum CybermanState
    {
        Idle,
        MovingToTask,
        DoingTask,
        MovingToVillage
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
            anim.SetBool("isMoving", true);
            anim.SetBool("isWorking", false);
            return CybermanState.MovingToVillage;
        }
        navAgent.SetDestination(CurrentTask.TaskLocation.position);
        if (NavAgentArrived())
        {
            Debug.Log("Cyberman arrived at " + CurrentTask.TaskLocation.position);
            anim.SetBool("isWorking", true);
            return CybermanState.DoingTask;
        }
        else
        {
            return CybermanState.MovingToTask;
        }
    }
    private CybermanState DoTask()
    {
        if (CurrentTask.TaskLocation == null)
        {
            return CybermanState.MovingToVillage;
        }
        workTimer += WORK_SPEED * Time.deltaTime;
        if (CurrentTask.Work.DoWork(workTimer))
        {
            workTimer = 0f;

            anim.SetBool("isWorking", false);
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
            anim.SetBool("isMoving", false);
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
        anim.SetBool("isMoving", true);
    }


}
