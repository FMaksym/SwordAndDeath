using UnityEngine;

public class PlayerHealth : HealthSystem
{
    [SerializeField] private DamageReceiver _damageReceiver;
    [SerializeField] private PlayerData _playerData;

    public delegate void PlayerHealthChanged(int currentHealth, int maxHealth);
    public delegate void PlayerDeath();
    public delegate void PlayerHit();
    public static event PlayerHealthChanged OnPlayerHealthChanged;
    public static event PlayerHit OnPlayerHit;
    public static event PlayerDeath OnPlayerDeath;

    private int MaxHealthPlayer => _playerData.MaxHealth;

    private void Start()
    {
        MaxHealth = MaxHealthPlayer;
        CurrentHealth = MaxHealth;
    }

    public void PlayerTakeDamage(int damage)
    {
        base.TakeDamage(damage);
        OnPlayerHit?.Invoke();
        OnPlayerHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        if (CurrentHealth > 0)
        {
            _damageReceiver.DamageEffect();
        }
    }

    protected override void HandleDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    private void OnDestroy()
    {
        OnPlayerDeath = null;
    }
}
