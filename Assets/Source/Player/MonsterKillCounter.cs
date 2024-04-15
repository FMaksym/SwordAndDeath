using UnityEngine;

public class MonsterKillCounter : MonoBehaviour
{
    private static int destroyedMonsterCount = 0;

    public delegate void MonsterKillCountUpdateAction(int count);
    public static event MonsterKillCountUpdateAction OnKillCountUpdate;

    private void Awake()
    {
        destroyedMonsterCount = 0;
    }

    public static void UpdateDestroyedMonsterCount()
    {
        destroyedMonsterCount++;
        OnKillCountUpdate?.Invoke(destroyedMonsterCount);
    }
}
