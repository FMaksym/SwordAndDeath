using UnityEngine;
using UnityEngine.SceneManagement;

public class UIView : MonoBehaviour
{
    public void UpdateHealthbar(UIModel uiModel, int playerCurrentHealth, int playerMaxHealth)
    {
        if (playerCurrentHealth >= 0)
        {
            float healthAmount = (float)playerCurrentHealth / playerMaxHealth;
            uiModel.PlayerHealth.fillAmount = healthAmount;
        }
    }

    public void UpdateKillsText(UIModel uiModel, int count)
    {
        uiModel.AmountOfKillGamePanelText.text = $"{count}";
        uiModel.AmountOfKillLosePanelText.text = $"{count}";
    }

    public void ClickStartGame(UIModel uiModel)
    {
        CloseCurrentOpenNewPanel(uiModel.MenuPanel, uiModel.GamePanel);
        uiModel.gameManager.InvokeStartGame();
        PlayClickSound(uiModel);
    }

    public void ClickPauseGame(UIModel uiModel)
    {
        OpenNewPanel(uiModel.PausePanel);
        uiModel.gameManager.InvokePauseGame();
        PlayClickSound(uiModel);
    }

    public void ClickResumeGame(UIModel uiModel)
    {
        ClosePanel(uiModel.PausePanel);
        uiModel.gameManager.InvokeResumeGame();
        PlayClickSound(uiModel);
    }
    
    public void OpenLosePanel(UIModel uiModel)
    {
        CloseCurrentOpenNewPanel(uiModel.GamePanel, uiModel.LosePanel);
        uiModel.gameManager.InvokeEndGame();
    }

    public void OpenInstruction(UIModel uiModel)
    {
        CloseCurrentOpenNewPanel(uiModel.MenuPanel, uiModel.InstructionsPanel);
        PlayClickSound(uiModel);
    }

    public void CloseInstruction(UIModel uiModel)
    {
        CloseCurrentOpenNewPanel(uiModel.InstructionsPanel, uiModel.MenuPanel);
        PlayClickSound(uiModel);
    }

    public void InMenu(UIModel uiModel)
    {
        PlayClickSound(uiModel);
        SceneManager.LoadScene(0);
    }

    public void QuitTheGame(UIModel uiModel)
    {
        PlayClickSound(uiModel);
        uiModel.gameManager.InvokeQuitGame();
    }

    private void CloseCurrentOpenNewPanel(RectTransform currentPanel, RectTransform newPanel)
    {
        ClosePanel(currentPanel);
        OpenNewPanel(newPanel);
    }

    private void OpenNewPanel(RectTransform rectTransform)
    {
        rectTransform.gameObject.SetActive(true);
    }

    private void ClosePanel(RectTransform rectTransform)
    {
        rectTransform.gameObject.SetActive(false);
    }

    private void PlayClickSound(UIModel uiModel)
    {
        uiModel.UIAudioSource.PlayOneShot(uiModel.ClickSound);
    }
}
