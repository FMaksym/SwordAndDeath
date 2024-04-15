using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIModel : MonoBehaviour
{
    [Header("Panels")]
    public RectTransform MenuPanel;
    public RectTransform InstructionsPanel;
    public RectTransform GamePanel;
    public RectTransform PausePanel;
    public RectTransform LosePanel;

    [Header("Player Healthbar")]
    public Image PlayerHealth;

    [Header("Texts")]
    public TMP_Text AmountOfKillGamePanelText;
    public TMP_Text AmountOfKillLosePanelText;

    [Header("UI Sound system")]
    public AudioSource UIAudioSource;
    public AudioClip ClickSound;

    [HideInInspector, Inject] public GameManager gameManager;
}
