using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int _currentHealth;
    private int _maxHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
        protected set
        {
            if (value <= 0)
            {
                _currentHealth = 0;
                HandleDeath();
            }
            if (value > MaxHealth)
            {
                _currentHealth = MaxHealth;
            }
            else
            {
                _currentHealth = value;
            }
        }
    }

    public int MaxHealth
    {
        get => _maxHealth;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Max health value must be positive.", nameof(MaxHealth));
            }
            _maxHealth = value;
        }
    }

    protected void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0)
        {
            damageAmount = 0;
        }

        if (CurrentHealth > 0)
        {
            CurrentHealth -= damageAmount;
        }
    }

    protected virtual void HandleDeath()
    {
    }
}
