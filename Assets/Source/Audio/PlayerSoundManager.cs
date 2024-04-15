using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [Header("Player Sounds")]
    [SerializeField] private AudioClip _playerAttackClip;
    [SerializeField] private AudioClip _playerHitClip;
    [SerializeField] private AudioClip _playerDeathClip;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerHit += PlayPlayerHitSound;
        PlayerHealth.OnPlayerDeath += PlayPlayerDeathSound;
    }

    public void PlayPlayerHitSound()
    {
        PlayClip(_playerHitClip);
    }

    public void PlayPlayerDeathSound()
    {
        PlayClip(_playerDeathClip);
    }

    public void PlayPlayerAttackSound()
    {
        PlayClip(_playerAttackClip);
    }

    private void PlayClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerHit -= PlayPlayerHitSound;
        PlayerHealth.OnPlayerDeath -= PlayPlayerDeathSound;
    }
}
