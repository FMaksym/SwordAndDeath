using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameHandler();
    public delegate void GameStart();
    public delegate void GamePause();
    public delegate void GameResume();
    public delegate void GameEnd();
    public delegate void GameQuit();

    public event GameHandler OnGameStart;
    public event GameHandler OnGamePause;
    public event GameHandler OnGameResume;
    public event GameHandler OnGameEnd;
    public event GameHandler OnGameQuit;

    private void OnEnable()
    {
        Time.timeScale = 0;

        OnGameStart += ResumeGame;
        OnGamePause += StopGame;
        OnGameResume += ResumeGame;
        OnGameEnd += StopGame;
        OnGameQuit += QuitGame;
    }

    public void InvokeStartGame() => OnGameStart?.Invoke();

    public void InvokePauseGame() => OnGamePause?.Invoke();

    public void InvokeResumeGame() => OnGameResume?.Invoke();

    public void InvokeEndGame() => OnGameEnd?.Invoke();

    public void InvokeQuitGame() => OnGameQuit?.Invoke();

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        OnGameStart -= ResumeGame;
        OnGamePause -= StopGame;
        OnGameResume -= ResumeGame;
        OnGameEnd -= StopGame;
        OnGameQuit -= QuitGame;
    }
}
