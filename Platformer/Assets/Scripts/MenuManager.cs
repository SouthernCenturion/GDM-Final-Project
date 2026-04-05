using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(2);
    }

    public void OpenHighScores()
    {
    SceneManager.LoadScene(3);
    }
}