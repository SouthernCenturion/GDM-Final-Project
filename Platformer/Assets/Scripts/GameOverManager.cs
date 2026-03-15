using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void TryAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(2);
    }
}