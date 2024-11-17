using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�klemek i�in
using UnityEngine.UI; // UI ��eleri ile etkile�im i�in

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;  // Ana men� paneli
    public GameObject optionsMenuUI; // Options paneli

    private void Start()
    {
        // Oyun ba�lad���nda ana men� a��k, options paneli kapal� olacak
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 0f; // Oyun dursun
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false); // Ana men� gizlensin
        Time.timeScale = 1f; // Oyun devam etsin
        // �lk sahneye ge�ebilir ya da mevcut sahneyi yeniden y�kleyebilirsiniz
        SceneManager.LoadScene("the last revelation"); // Ana sahnenizin ad�n� kullan�n
    }

    public void OpenOptions()
    {
        optionsMenuUI.SetActive(true); // Options panelini a��n
    }

    public void CloseOptions()
    {
        optionsMenuUI.SetActive(false); // Options panelini kapat�n
    }

    public void QuitGame()
    {
        Application.Quit(); // Oyun kapans�n
        Debug.Log("Oyun kapat�ld�."); // Editor i�inde �al���rken ��k��� g�sterir
����}

}