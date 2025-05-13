using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    
    public static GameOverManager instance;
    private GameObject gameOverPanel;
    private Animator gameOverAnim;
    private Button retryButton, menuButton;
    private Text score;
    private GameObject scoreText;
    public Text highScore;

    void Awake()
    {
        MakeInstance();
        InitializeVariable();
    }

    public void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ShowGameOverPanel()
    {
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);
        ScoreManager.instance.GetHighScore();
        score.text = "Score:\n" + "" + ScoreManager.instance.GetScore();
        highScore.text = "High Score:\n" + PlayerPrefs.GetInt("highScore").ToString();
        NGHelper.instance.submitScore(14881, ScoreManager.instance.score);
        gameOverAnim.Play("GameOverPanelFadeIn");
    }

    void InitializeVariable()
    {
        gameOverPanel = GameObject.Find("GameOverPanelHolder");
        gameOverAnim = gameOverPanel.GetComponent<Animator>();
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        retryButton.onClick.AddListener(() => PlayAgain());
        menuButton.onClick.AddListener(() => Menu());
        scoreText = GameObject.Find("ScoreText");
        score = GameObject.Find("Score").GetComponent<Text>();
        gameOverPanel.SetActive(false);
    }

    public void PlayAgain()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
