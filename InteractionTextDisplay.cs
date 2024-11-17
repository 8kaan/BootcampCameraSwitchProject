using UnityEngine;
using TMPro; // TextMeshPro için gerekli namespace

public class InteractionTextDisplay : MonoBehaviour
{
    private bool isPlayerInRange = false; // Oyuncu nesnenin yakýnýnda mý?
    public GameObject textUI;  // Ekranda gösterilecek yazý (mesaj)
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI komponenti
    public TextMeshProUGUI interactionPrompt; // Press E mesajý

    private void Start()
    {
        // Baþlangýçta textUI'yi ve interactionPrompt'u gizle
        if (textUI != null)
        {
            textUI.SetActive(false);
        }

        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false); // Baþlangýçta 'Press E' mesajýný gizle
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Oyuncu nesneye yaklaþtýðýnda 'Press E' mesajýný göster
            Debug.Log("Etkileþim baþlatýldý!");
            ShowInteractionPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Oyuncu nesneden uzaklaþtýðýnda yazýyý ve 'Press E' mesajýný gizle
            Debug.Log("Etkileþim sona erdi!");
            HideText();
            HideInteractionPrompt();
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // E tuþuna basýldýðýnda yazýyý göster
            ShowText();
            HideInteractionPrompt(); // E tuþuna basýldýðýnda Press E'yi gizle
        }
    }

    private void ShowText()
    {
        // TextUI'yi göster ve mesajý yaz
        if (textUI != null && textMeshPro != null)
        {
            textUI.SetActive(true);
            textMeshPro.text = "You are trapped in a dream, \nIf you want to escape from this place, \nyou have to answer Guardian's questions and collect 10 points\nGood Luck!"; // Mesajý yaz
        }
    }

    private void HideText()
    {
        // TextUI'yi gizle
        if (textUI != null)
        {
            textUI.SetActive(false);
        }
    }

    private void ShowInteractionPrompt()
    {
        // 'Press E' mesajýný göster
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(true);
            interactionPrompt.text = "Press E to interact";
        }
    }

    private void HideInteractionPrompt()
    {
        // 'Press E' mesajýný gizle
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false);
        }
    }
}