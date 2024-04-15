using UnityEngine;

public class PlayerIdleState : PlayerState
{
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private IdleBehaviour _idleBehaviour;
    [SerializeField] private AttackBehaviour _attackBehaviour;

    [SerializeField] private PlayerState _crouchState;

    public override PlayerState RunCurrentState()
    {
        if (_idleBehaviour.IsCrouch())
        {
            _idleBehaviour.PlayerIdleAnimation(_playerData.PlayerAnimator, false);
            _idleBehaviour.PlayerStay();

            return _crouchState;
        }
        else
        {
            _idleBehaviour.PlayerStay();

            _idleBehaviour.PlayerIdleAnimation(_playerData.PlayerAnimator, true);

            if (_attackBehaviour.IsPlayerAttack())
            {
                _attackBehaviour.PlayerIdleAttack(_playerData);
            }
            return this;
        }
    }
}
