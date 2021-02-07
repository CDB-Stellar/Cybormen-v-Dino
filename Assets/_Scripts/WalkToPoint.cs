using UnityEngine;
using UnityEngine.AI;

public class WalkToPoint : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.isOnNavMesh);
        agent.SetDestination(destination.position);
    }
}
