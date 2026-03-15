using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScore;
        GameManager.Instance.OnHealthChanged -= UpdateHealth;
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }

    void UpdateScore(int newScore)
    {
        Debug.Log("Score event fired: " + newScore);
        scoreText.text = "Score: " + newScore;
    }

    void UpdateHealth(int newHealth)
    {
        Debug.Log("Health event fired: " + newHealth);
        healthText.text = "Health: " + newHealth;
    }

    void HandleGameOver()
    {
        Debug.Log("Game over event fired");
        SceneManager.LoadScene(0);
    }
}