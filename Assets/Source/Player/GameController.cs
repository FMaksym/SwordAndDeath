using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GameController : MonoBehaviour
{
    public delegate void InputEvent();
    public static event InputEvent StartLeftAttacked;
    public static event InputEvent StartRightAttacked;
    public static event InputEvent Crouch;
    public static event InputEvent EndCrouch;

    public void PlayerAttackLeftSide(CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Left");
            StartLeftAttacked?.Invoke();
        }
    }

    public void PlayerAttackRightSide(CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Right");
            StartRightAttacked?.Invoke();
        }
    }

    public void PlayerCrouch(CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Crouch");
            Crouch?.Invoke();
        }
        else if (context.canceled) 
        {
            EndCrouch?.Invoke();
        }
    }
}
