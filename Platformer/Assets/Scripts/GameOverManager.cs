using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }
}