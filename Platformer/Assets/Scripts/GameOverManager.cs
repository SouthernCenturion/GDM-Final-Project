using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Final Score: " + GameManager.Instance.score;
    }

    public void OnSubmitScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        int finalScore = GameManager.Instance.score;
        float completionTime = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);

        SceneManager.LoadScene("HighScore");
    }

    public void TryAgain()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(2);
    }
}