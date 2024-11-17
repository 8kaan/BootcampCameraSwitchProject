using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance { get; private set; }

    public List<Question> questions;
    private int currentQuestionIndex = -1;

    // UI Elemanlarý için referanslar
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private TextMeshProUGUI scoreText; // Puan göstermek için yeni bir UI elemaný

    private int score = 0; // Oyuncunun puaný

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadQuestions();
        UpdateScoreText(); // Baþlangýçta puaný göstermek için
    }

    private void LoadQuestions()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "questions.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);

            if (questions == null || questions.Count == 0)
            {
                Debug.LogError("Sorular yüklenemedi veya liste boþ.");
            }
        }
        else
        {
            Debug.LogError("Sorular dosyasý bulunamadý.");
        }
    }

    public void AskQuestion()
    {
        if (questions == null || questions.Count == 0)
        {
            Debug.LogError("Sorular mevcut deðil.");
            return;
        }

        currentQuestionIndex = (currentQuestionIndex + 1) % questions.Count;

        var question = questions[currentQuestionIndex];
        questionText.text = $"Question: {question.question}";  // Soru ekrana yazdýrýlýyor
        feedbackText.text = "";  // Cevap geri bildirimini temizliyoruz
    }

    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer.ToLower() == questions[currentQuestionIndex].answer.ToLower())
        {
            feedbackText.text = "You are right!";  // Doðru cevap geri bildirimi
            AddScore(3); // Doðru cevap için 3 puan ekle
        }
        else
        {
            feedbackText.text = "You are wrong.";  // Yanlýþ cevap geri bildirimi
            AddScore(-1); // Yanlýþ cevap için 1 puan çýkar
        }
    }

    private void AddScore(int points)
    {
        score += points;
        if (score < 0) score = 0; // Puan negatif olamaz
        UpdateScoreText();

        if (score >= 10)
        {
            feedbackText.text = "Congratulations, you won the game!"; // Oyunu kazandýnýz mesajý
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}"; // Puaný ekrana yazdýr
    }

    [System.Serializable]
    public class Question
    {
        public string question;
        public string answer;
    }
}