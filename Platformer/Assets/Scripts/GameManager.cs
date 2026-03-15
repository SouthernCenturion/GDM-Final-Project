using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int health = 100;

    public delegate void ScoreChanged(int newScore);
    public delegate void HealthChanged(int newHealth);
    public delegate void GameOver();

    public event ScoreChanged OnScoreChanged;
    public event HealthChanged OnHealthChanged;
    public event GameOver OnGameOver;

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ResetGame()
    {
    score = 0;
    health = 100;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}