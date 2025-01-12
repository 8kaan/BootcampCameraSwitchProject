using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public Transform player; // Oyuncuyu tanımlayacağımız alan
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileşenini al
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Oyuncunun konumuna git
        }
    }
}