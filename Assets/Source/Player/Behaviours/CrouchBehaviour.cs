using UnityEngine;

public class CrouchBehaviour : MonoBehaviour
{
    [SerializeField] private bool _isCrouch = false;

    private void OnEnable()
    {
        GameController.Crouch += PlayerStartCrouch;
        GameController.EndCrouch += PlayerEndCrouch;
    }

    public void PlayerCrouchAnimation(Animator animator, bool value)
    {
        animator.SetBool("Crouch", value);
    }

    public void PlayerCrouchAnimationTrigger(Animator animator)
    {
        animator.SetTrigger("Sit");
    }

    private void PlayerStartCrouch()
    {
        _isCrouch = true;
    }

    private void PlayerEndCrouch()
    {
        _isCrouch = false;
    }

    public bool IsCrouch() => _isCrouch;

    private void OnDisable()
    {
        GameController.Crouch -= PlayerStartCrouch;
    }
}
