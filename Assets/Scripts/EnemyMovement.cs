using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }


    }
}
