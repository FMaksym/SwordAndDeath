using UnityEngine;

public class EnemyRunBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private LayerMask _playerLayer;

    private bool _playerInAttackRadius;
    private Vector2 _playerTransform;

    private void OnEnable()
    {
        _playerInAttackRadius = false;
        _enemyAnimator.SetBool("Idle", false);
        _enemyAnimator.SetBool("Run", true);
    }

    private void Awake()
    {
        _playerTransform = FindObjectOfType<PlayerData>().gameObject.transform.position;
    }

    public void MoveTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            Vector2 direction = (_playerTransform - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.Translate(direction * _enemyData.MoveSpeed * Time.deltaTime);

            PlayerDetecting();
        }
    }

    public bool PlayerInAttackRange()
    {
        return _playerInAttackRadius;
    }

    private void PlayerDetecting()
    {
        _playerInAttackRadius = Physics2D.OverlapCircle(transform.position, _enemyData.AttackRadius, _playerLayer);

        if (_playerInAttackRadius)
        {
            _enemyAnimator.SetBool("Run", false);
        }
        else
        {
            _enemyAnimator.SetBool("Run", true);
        }
    }
}
