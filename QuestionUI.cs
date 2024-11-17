using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public TMP_InputField answerInput;
    public QuestionManager questionManager;

    public void OnSubmitAnswer()
    {
        string playerAnswer = answerInput.text;

        if (string.IsNullOrWhiteSpace(playerAnswer)) // Bo� veya yaln�zca bo�luk olan cevaplar� kontrol edin
        {
            Debug.Log("Cevap bo� veya yaln�zca bo�luk!");
        }
        else
        {
            
            questionManager.CheckAnswer(playerAnswer);
        }

        // Yan�t verildikten sonra input alan�n� temizleyebilirsiniz
        answerInput.text = "";
    }


}
