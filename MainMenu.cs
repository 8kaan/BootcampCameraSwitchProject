using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yüklemek için
using UnityEngine.UI; // UI öðeleri ile etkileþim için

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;  // Ana menü paneli
    public GameObject optionsMenuUI; // Options paneli

    private void Start()
    {
        // Oyun baþladýðýnda ana menü açýk, options paneli kapalý olacak
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 0f; // Oyun dursun
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false); // Ana menü gizlensin
        Time.timeScale = 1f; // Oyun devam etsin
        // Ýlk sahneye geçebilir ya da mevcut sahneyi yeniden yükleyebilirsiniz
        SceneManager.LoadScene("the last revelation"); // Ana sahnenizin adýný kullanýn
    }

    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true); // Options panelini açýn
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false); // Options panelini kapatýn
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyun kapansýn
        Debug.Log("Oyun kapatýldý."); // Editor içinde çalýþýrken çýkýþý gösterir
    }

}