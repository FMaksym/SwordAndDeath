using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private AudioSource _audioSource;

    [Header("Enemies Sounds")]
    [SerializeField] private AudioClip _enemyHitClip;
    [SerializeField] private AudioClip _enemyDeathClip;
    [SerializeField] private AudioClip _enemyAttackClip;

    private void OnEnable()
    {
        _enemyHealth.OnEnemyDeath += PlayEnemyDeathSound;
        _enemyHealth.OnEnemyHit += PlayEnemyHitSound;
    }

    public void PlayEnemyDeathSound()
    {
        PlayClip(_enemyDeathClip);
    }
    public void PlayEnemyHitSound()
    {
        PlayClip(_enemyHitClip);
    }

    public void PlayEnemyAttackSound()
    {
        PlayClip(_enemyAttackClip);
    }

    private void PlayClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    private void OnDisable()
    {
        _enemyHealth.OnEnemyDeath += PlayEnemyDeathSound;
        _enemyHealth.OnEnemyHit += PlayEnemyHitSound;
    }
}
