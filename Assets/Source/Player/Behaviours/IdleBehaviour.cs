using UnityEngine;

public class IdleBehaviour : MonoBehaviour
{
    [SerializeField] private bool _isIdle = false;
    [SerializeField] private bool _isCrouch = false;

    private void OnEnable()
    {
        GameController.Crouch += PlayerCrouch;
    }

    private void Start()
    {
        PlayerStay();
    }
    public void PlayerStay()
    {
        _isIdle = true;
        _isCrouch = false;
    }

    public void PlayerDontIdle()
    {
        _isIdle = false;
    }

    public void PlayerIdleAnimation(Animator animator, bool value)
    {
        animator.SetBool("Idle", value);
    }

    public bool IsIdle() => _isIdle;
    public bool IsCrouch() => _isCrouch;

    private void PlayerCrouch()
    {
        if (!_isCrouch) 
        {
            _isCrouch = true; 
            _isIdle = false; 
        }
    }

    private void OnDisable()
    {
        GameController.Crouch -= PlayerCrouch;
    }
}
