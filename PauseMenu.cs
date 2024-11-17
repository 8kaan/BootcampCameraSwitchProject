using UnityEngine;
using UnityEngine.UI; // UI ��eleri ile etkile�im i�in


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Pause men�s� Canvas'�
    public GameObject optionsMenuUI; // Options paneli
    private bool isPaused = false; // Oyunun duraklat�l�p duraklat�lmad���n� kontrol eder

    void Update()
    {
        // ESC tu�una bas�ld���nda Pause veya Resume i�lemini yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Duraklat�lm��sa devam ettir
            }
            else
            {
                Pause(); // Duraklat�lmam��sa duraklat
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Pause men�s�n� gizle
        Time.timeScale = 1f; // Zaman� normal h�z�na getir
        isPaused = false; // Duraklama durumunu kapat
    }
    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true); // Options panelini a��n
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false); // Options panelini kapat�n
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Pause men�s�n� g�ster
        Time.timeScale = 0f; // Zaman� durdur
        isPaused = true; // Duraklama durumunu aktif et
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyunu kapat
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Edit�rde �al���yorsa durdur
#endif
    }
}