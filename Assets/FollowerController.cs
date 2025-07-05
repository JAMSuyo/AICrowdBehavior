using UnityEngine;
using UnityEngine.AI;

public class FollowerAI : MonoBehaviour
{
    public Transform leader;
    public Vector3 offset;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FollowLeader();
        InvokeRepeating("FollowLeader", Random.Range(0.1f, 0.3f), 0.2f); 
    }

    void FollowLeader()
    {
        if (leader != null)
        {
            Debug.Log($"{gameObject.name} is following {leader.name}");
            Vector3 targetPos = leader.position + leader.TransformDirection(offset);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(targetPos, out hit, 2f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }
}
