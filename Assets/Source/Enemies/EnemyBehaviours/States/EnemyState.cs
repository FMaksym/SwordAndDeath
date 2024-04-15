using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public abstract EnemyState RunCurrentState();
}
