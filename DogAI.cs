using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public Transform player; // Oyuncuyu tan�mlayaca��m�z alan
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�enini al
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Oyuncunun konumuna git
 �������}
    }
}