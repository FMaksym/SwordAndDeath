using System.Collections;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Vector2 _attackSize = new Vector2(2f, 0.5f);

    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Transform _idleAttackRightPoint;
    [SerializeField] private Transform _crouchAttackRightPoint;

    [SerializeField] private Transform _idleAttackLeftPoint;
    [SerializeField] private Transform _crouchAttackLeftPoint;

    private bool _isLeftAttack = false;
    private bool _isRightAttack = false;

    private bool _canAttack = true;

    private void OnEnable()
    {
        _canAttack = true;
        GameController.StartLeftAttacked += PlayerLeftAttack;
        GameController.StartRightAttacked += PlayerRightAttack;
    }

    public void PlayerIdleAttack(PlayerData playerData)
    {
        if (_canAttack)
        {
            if (_isLeftAttack)
            {
                PlayerAttack(playerData, "AttackIdle", true);
                Attack(_idleAttackLeftPoint.position);
            }
            else if (_isRightAttack)
            {
                PlayerAttack(playerData, "AttackIdle");
                Attack(_idleAttackRightPoint.position);
            }
            
            PlayerNotAttack();

            StartCoroutine(AttackCooldown(playerData.AttackCooldown));
        }
    }

    public void PlayerCrouchAttack(PlayerData playerData)
    {
        if (_canAttack)
        {
            if (_isLeftAttack)
            {
                PlayerAttack(playerData, "AttackCrouch", true);
                Attack(_crouchAttackLeftPoint.position);
            }
            else if (_isRightAttack)
            {
                PlayerAttack(playerData, "AttackCrouch");
                Attack(_crouchAttackRightPoint.position);
            }

            PlayerNotAttack();

            StartCoroutine(AttackCooldown(playerData.AttackCooldown));
        }
    }

    public bool IsPlayerAttack() => _isLeftAttack || _isRightAttack;

    public void Attack(Vector2 attackPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackPoint, _attackSize, 0, _enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.activeInHierarchy)
            {
                EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.EnemyTakeDamage(_playerData.Damage);
                }
            }
        }
    }

    private void PlayerAttack(PlayerData playerData, string TriggerName, bool flipXValue = false)
    {
        PlayerSpriteFlip(playerData.PlayerSpriteRenderer, flipXValue);
        SetAttackTrigger(playerData, TriggerName);
    }

    private void PlayerSpriteFlip(SpriteRenderer spriteRenderer, bool flipXValue)
    {
        spriteRenderer.flipX = flipXValue;
    }

    private void SetAttackTrigger(PlayerData playerData, string TriggerName)
    {
        playerData.PlayerAnimator.SetTrigger(TriggerName);
    }

    private void PlayerLeftAttack()
    {
        _isLeftAttack = true;
    }

    private void PlayerRightAttack()
    {
        _isRightAttack = true;
    }

    private void PlayerNotAttack()
    {
        _isLeftAttack = false;
        _isRightAttack = false;
    }

    private IEnumerator AttackCooldown(float cooldownTime)
    {
        _canAttack = false;
        yield return new WaitForSeconds(cooldownTime);
        _canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_idleAttackRightPoint.position, _attackSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_crouchAttackRightPoint.position, _attackSize);
    }

    private void OnDisable()
    {
        GameController.StartLeftAttacked -= PlayerLeftAttack;
        GameController.StartRightAttacked -= PlayerRightAttack;
    }
}
