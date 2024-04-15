using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerState currentState;

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        PlayerState nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(PlayerState nextState)
    {
        currentState = nextState;
    }
}
