using UnityEngine;
using TMPro; // TextMeshPro i�in gerekli namespace

public class InteractionTextDisplay : MonoBehaviour
{
    private bool isPlayerInRange = false; // Oyuncu nesnenin yak�n�nda m�?
    public GameObject textUI;  // Ekranda g�sterilecek yaz� (mesaj)
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI komponenti
    public TextMeshProUGUI interactionPrompt; // Press E mesaj�

    private void Start()
    {
        // Ba�lang��ta textUI'yi ve interactionPrompt'u gizle
        if (textUI != null)
        {
            textUI.SetActive(false);
        }

        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false); // Ba�lang��ta 'Press E' mesaj�n� gizle
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Oyuncu nesneye yakla�t���nda 'Press E' mesaj�n� g�ster
            Debug.Log("Etkile�im ba�lat�ld�!");
            ShowInteractionPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Oyuncu nesneden uzakla�t���nda yaz�y� ve 'Press E' mesaj�n� gizle
            Debug.Log("Etkile�im sona erdi!");
            HideText();
            HideInteractionPrompt();
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // E tu�una bas�ld���nda yaz�y� g�ster
            ShowText();
            HideInteractionPrompt(); // E tu�una bas�ld���nda Press E'yi gizle
        }
    }

    private void ShowText()
    {
        // TextUI'yi g�ster ve mesaj� yaz
        if (textUI != null && textMeshPro != null)
        {
            textUI.SetActive(true);
            textMeshPro.text = "You are trapped in a dream, \nIf you want to escape from this place, \nyou have to answer Guardian's questions and collect 10 points\nGood Luck!"; // Mesaj� yaz
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
        // 'Press E' mesaj�n� g�ster
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(true);
            interactionPrompt.text = "Press E to interact";
        }
    }

    private void HideInteractionPrompt()
    {
        // 'Press E' mesaj�n� gizle
        if (interactionPrompt != null)
        {
            interactionPrompt.gameObject.SetActive(false);
        }
    }
}