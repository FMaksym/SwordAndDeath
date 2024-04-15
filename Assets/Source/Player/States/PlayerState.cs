using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public abstract PlayerState RunCurrentState();
}
