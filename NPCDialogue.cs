using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private bool isPlayerInRange = false; // Oyuncu NPC'nin yak�n�nda m�?
    public GameObject chatUI;  // Chat UI (Input Field ve Chat Log) 

    private void Start()
    {
        // Ba�lang��ta chat UI'yi gizle
        if (chatUI != null)
        {
            chatUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Oyuncu NPC'ye yakla�t���nda diyalo�u ba�latma
            Debug.Log("NPC ile etkile�im ba�lat�ld�!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // NPC'den uzakla��ld���nda diyalo�u kapat
            Debug.Log("NPC ile etkile�im sona erdi!");
            HideDialogue();
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Chat UI'yi a�
            ShowDialogue();

            // NPC ile etkile�ime girildi�inde, sorular� sormaya ba�la
            QuestionManager.Instance.AskQuestion();
        }
    }

    private void ShowDialogue()
    {
        // Chat UI'yi g�ster
        if (chatUI != null)
        {
            chatUI.SetActive(true);
        }
    }

    private void HideDialogue()
    {
        // Chat UI'yi gizle
        if (chatUI != null)
        {
            chatUI.SetActive(false);
        }
    }
}