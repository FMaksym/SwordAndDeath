using UnityEngine;

public class EnemyIdleState : EnemyState
{
    [SerializeField] private EnemyIdleBehaviour _enemyIdleBehaviour;
    [SerializeField] private EnemyRunBehaviour _enemyRunBehaviour;
    [SerializeField] private EnemyAttackBehaviour _enemyAttackBehaviour;

    [SerializeField] private EnemyRunState _enemyRunState;

    public override EnemyState RunCurrentState()
    {
        if (_enemyRunBehaviour.PlayerInAttackRange())
        {
            _enemyIdleBehaviour.PlayerIdleAnimation();

            if (_enemyAttackBehaviour.CanAttack())
            {
                _enemyAttackBehaviour.AttackEnemy();
            }

            return this;
        }
        else
        {
            _enemyIdleBehaviour.EnemyNotIdle();
            return _enemyRunState;
        }
    }
}
