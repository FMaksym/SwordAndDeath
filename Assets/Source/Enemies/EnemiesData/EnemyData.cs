using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Health")]
    public int MaxHealth;
    public float DeathDuration;

    [Header("Movement")]
    public float MoveSpeed;

    [Header("Attack System")]
    public int Damage;
    public float AttackFrequency;
    public float AttackRadius;
}
