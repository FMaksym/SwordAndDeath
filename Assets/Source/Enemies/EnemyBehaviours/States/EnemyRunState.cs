using UnityEngine;

public class EnemyRunState : EnemyState
{
    [SerializeField] private EnemyRunBehaviour _enemyRunBehaviour;

    [SerializeField] private EnemyIdleState _enemyIdleState;

    public override EnemyState RunCurrentState()
    {
        if (!_enemyRunBehaviour.PlayerInAttackRange())
        {
            _enemyRunBehaviour.MoveTowardsPlayer();
            return this;
        }
        else
        {
            return _enemyIdleState;
        }
        
    }
}
