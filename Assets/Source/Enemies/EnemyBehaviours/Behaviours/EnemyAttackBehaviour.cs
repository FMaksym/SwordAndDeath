using System.Collections;
using UnityEngine;

public class EnemyAttackBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyDieBehaviour _enemyDieBehaviour;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private EnemyData _enemyData;

    private bool _canAttack;
    private PlayerData _playerData;

    private void OnEnable()
    {
        _canAttack = true;
    }

    public void Initialize(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public bool CanAttack() => _canAttack;

    public void AttackEnemy()
    {
        if (_canAttack && !_enemyDieBehaviour.IsDied())
        {
            SetAttackTrigger();
            _canAttack = false;
            StartCoroutine(WaitForNextAttack(_enemyData.AttackFrequency));
        }
    }

    private void SetAttackTrigger()
    {
        _enemyAnimator.SetTrigger("Attack");
    }

    private IEnumerator WaitForNextAttack(float time)
    {
        yield return new WaitForSeconds(time);
        _canAttack = true;
    }

    public void HitPlayer()
    {
        _playerData.PlayerHealth.PlayerTakeDamage(_enemyData.Damage);
    }
}
