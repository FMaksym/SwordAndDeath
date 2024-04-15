using UnityEngine;

public class PlayerCrouchState : PlayerState
{
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private CrouchBehaviour _crouchBehaviour;
    [SerializeField] private AttackBehaviour _attackBehaviour;

    [SerializeField] private PlayerState _idleState;

    public override PlayerState RunCurrentState()
    {
        if (_crouchBehaviour.IsCrouch())
        {
            _crouchBehaviour.PlayerCrouchAnimation(_playerData.PlayerAnimator, true);

            if (_attackBehaviour.IsPlayerAttack())
            {
                _attackBehaviour.PlayerCrouchAttack(_playerData);
            }

            return this;
        }
        else
        {
            _crouchBehaviour.PlayerCrouchAnimation(_playerData.PlayerAnimator, false);
            return _idleState;
        }
    }
}
