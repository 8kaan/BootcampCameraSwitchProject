using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public Transform player; // Oyuncuyu tanýmlayacaðýmýz alan
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþenini al
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Oyuncunun konumuna git
        }
    }
}