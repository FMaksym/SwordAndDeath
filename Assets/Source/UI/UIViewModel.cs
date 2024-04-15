using UnityEngine;

public class UIViewModel : MonoBehaviour
{
    public UIModel uiModel;
    public UIView uiView;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerHealthChanged += UpdatePlayerHealthbar;
        MonsterKillCounter.OnKillCountUpdate += UpdateKillCount;
        PlayerHealth.OnPlayerDeath += LoseGame;
    }

    public void OnClickPlay()
    {
        uiView.ClickStartGame(uiModel);
    }

    public void OnClickPauseGame()
    {
        uiView.ClickPauseGame(uiModel);
    }

    public void OnClickResumeGame()
    {
        uiView.ClickResumeGame(uiModel);
    }

    public void LoseGame()
    {
        uiView.OpenLosePanel(uiModel);
    }

    public void OnClickInstruction()
    {
        uiView.OpenInstruction(uiModel);
    }

    public void OnClickCloseInstruction()
    {
        uiView.CloseInstruction(uiModel);
    }

    public void OnClickInMenu()
    {
        uiView.InMenu(uiModel);
    }

    public void OnClickQuitTheGame()
    {
        uiView.QuitTheGame(uiModel);
    }

    public void UpdateKillCount(int count)
    {
        uiView.UpdateKillsText(uiModel, count);
    }

    public void UpdatePlayerHealthbar(int playerCurrentHealth, int playerMaxHealth)
    {
        uiView.UpdateHealthbar(uiModel, playerCurrentHealth, playerMaxHealth);
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerHealthChanged -= UpdatePlayerHealthbar;
        MonsterKillCounter.OnKillCountUpdate -= UpdateKillCount;
        PlayerHealth.OnPlayerDeath -= LoseGame;
    }
}
