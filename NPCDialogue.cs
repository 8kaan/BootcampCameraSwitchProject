using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private bool isPlayerInRange = false; // Oyuncu NPC'nin yakýnýnda mý?
    public GameObject chatUI;  // Chat UI (Input Field ve Chat Log) 

    private void Start()
    {
        // Baþlangýçta chat UI'yi gizle
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
            // Oyuncu NPC'ye yaklaþtýðýnda diyaloðu baþlatma
            Debug.Log("NPC ile etkileþim baþlatýldý!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // NPC'den uzaklaþýldýðýnda diyaloðu kapat
            Debug.Log("NPC ile etkileþim sona erdi!");
            HideDialogue();
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Chat UI'yi aç
            ShowDialogue();

            // NPC ile etkileþime girildiðinde, sorularý sormaya baþla
            QuestionManager.Instance.AskQuestion();
        }
    }

    private void ShowDialogue()
    {
        // Chat UI'yi göster
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