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

        if (string.IsNullOrWhiteSpace(playerAnswer)) // Boþ veya yalnýzca boþluk olan cevaplarý kontrol edin
        {
            Debug.Log("Cevap boþ veya yalnýzca boþluk!");
        }
        else
        {
            
            questionManager.CheckAnswer(playerAnswer);
        }

        // Yanýt verildikten sonra input alanýný temizleyebilirsiniz
        answerInput.text = "";
    }


}
