using UnityEngine;

public class EnemyIdleBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;

    private bool _isIdle = false;

    public void EnemyNotIdle()
    {
        _isIdle = false;
    }

    public void PlayerIdleAnimation()
    {
        if (!_isIdle)
        {
            _enemyAnimator.SetBool("Idle", true);
            _isIdle = true;
        }
    }
}
