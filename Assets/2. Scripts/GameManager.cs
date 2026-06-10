using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool isGameStarted = false;
    public bool isGameOver = false;
    public bool isGameWin = false;

    public GameObject startButton;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        isGameWin = false;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        isGameStarted = true;
        startButton.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        isGameOver = true;
        isGameWin = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Win()
    {
        isGameOver = true;
        isGameWin = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
