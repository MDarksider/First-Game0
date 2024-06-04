using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int life = 3;

    public static GameManager Instance;
    public Button startButton;
    public Button exitButton;
    public Text scoreText;
    public Text lifeText;
    public Text winnerText;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
    }

    void Update()
    {
        Checker();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void StartGame()
    {
        Time.timeScale = 1f;
        startButton.gameObject.SetActive(false);
    }
    public void ExitGame()
    {

        Time.timeScale = 1f;

        exitButton.gameObject.SetActive(false);
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;

    }

    public void LifeChecker()
    {
        life--;
        lifeText.text = "Life: " + life;

    }

    void Checker()
    {
        if (score == 10)
        {
            winnerText.text = "Winner Winner Chicken Dinner";

            Invoke("Restart", 2);
        }
    }


    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        exitButton.onClick.RemoveListener(ExitGame);
    }



}
  
