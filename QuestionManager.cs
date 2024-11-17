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

    // UI Elemanlar� i�in referanslar
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private TextMeshProUGUI scoreText; // Puan g�stermek i�in yeni bir UI eleman�

    private int score = 0; // Oyuncunun puan�

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
        UpdateScoreText(); // Ba�lang��ta puan� g�stermek i�in
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
                Debug.LogError("Sorular y�klenemedi veya liste bo�.");
            }
        }
        else
        {
            Debug.LogError("Sorular dosyas� bulunamad�.");
        }
    }

    public void AskQuestion()
    {
        if (questions == null || questions.Count == 0)
        {
            Debug.LogError("Sorular mevcut de�il.");
            return;
        }

        currentQuestionIndex = (currentQuestionIndex + 1) % questions.Count;

        var question = questions[currentQuestionIndex];
        questionText.text = $"Question: {question.question}";  // Soru ekrana yazd�r�l�yor
        feedbackText.text = "";  // Cevap geri bildirimini temizliyoruz
    }

    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer.ToLower() == questions[currentQuestionIndex].answer.ToLower())
        {
            feedbackText.text = "You are right!";  // Do�ru cevap geri bildirimi
            AddScore(3); // Do�ru cevap i�in 3 puan ekle
        }
        else
        {
            feedbackText.text = "You are wrong.";  // Yanl�� cevap geri bildirimi
            AddScore(-1); // Yanl�� cevap i�in 1 puan ��kar
        }
    }

    private void AddScore(int points)
    {
        score += points;
        if (score < 0) score = 0; // Puan negatif olamaz
        UpdateScoreText();

        if (score >= 10)
        {
            feedbackText.text = "Congratulations, you won the game!"; // Oyunu kazand�n�z mesaj�
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}"; // Puan� ekrana yazd�r
    }

    [System.Serializable]
    public class Question
    {
        public string question;
        public string answer;
    }
}