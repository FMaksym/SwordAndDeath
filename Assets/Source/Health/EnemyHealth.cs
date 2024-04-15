using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private DamageReceiver _damageReceiver;
    [SerializeField] private EnemyData _enemyData;

    public delegate void EnemyDeath();
    public delegate void EnemyHit();
    public event EnemyDeath OnEnemyDeath;
    public event EnemyDeath OnEnemyHit;

    private int MaxHealthEnemy => _enemyData.MaxHealth;

    private void OnEnable()
    {
        MaxHealth = MaxHealthEnemy;
        CurrentHealth = MaxHealth;
    }

    public void EnemyTakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (CurrentHealth > 0)
        {
            OnEnemyHit?.Invoke();
            _damageReceiver.DamageEffect();
        }
    }

    protected override void HandleDeath()
    {
        OnEnemyDeath?.Invoke();
        CurrentHealth = MaxHealth;
    }

    private void OnDestroy()
    {
        OnEnemyDeath = null;
    }
}
