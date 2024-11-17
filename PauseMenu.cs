using UnityEngine;
using UnityEngine.UI; // UI öðeleri ile etkileþim için


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Pause menüsü Canvas'ý
    public GameObject optionsMenuUI; // Options paneli
    private bool isPaused = false; // Oyunun duraklatýlýp duraklatýlmadýðýný kontrol eder

    void Update()
    {
        // ESC tuþuna basýldýðýnda Pause veya Resume iþlemini yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Duraklatýlmýþsa devam ettir
            }
            else
            {
                Pause(); // Duraklatýlmamýþsa duraklat
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Pause menüsünü gizle
        Time.timeScale = 1f; // Zamaný normal hýzýna getir
        isPaused = false; // Duraklama durumunu kapat
    }
    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true); // Options panelini açýn
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false); // Options panelini kapatýn
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Pause menüsünü göster
        Time.timeScale = 0f; // Zamaný durdur
        isPaused = true; // Duraklama durumunu aktif et
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Editörde çalýþýyorsa durdur
#endif
    }
}