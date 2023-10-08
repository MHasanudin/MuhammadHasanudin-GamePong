using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SceneManagement sceneManagement;
    public Countdown countdown;

    public GameObject _gameOver = null;
    public GameObject _pause = null;

    private void Start()
    {
        countdown.StartCount();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pause.SetActive(true);
    }

    public void Resume()
    {
        countdown.StartCount();
        _pause.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOver.SetActive(true);
    }

    public void MainMenu()
    {
        sceneManagement.MainMenu();
    }
}
