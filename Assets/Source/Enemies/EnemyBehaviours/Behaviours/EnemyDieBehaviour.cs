using System.Collections;
using UnityEngine;

public class EnemyDieBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Animator _enemyAnimator;

    private bool _isDied;

    private void OnEnable()
    {
        _enemyHealth.OnEnemyDeath += EnemyDie;
        _isDied = false;
    }
    
    public bool IsDied() => _isDied;

    private void EnemyDie() 
    {
        _isDied = true;
        _enemyAnimator.SetTrigger("Die");
        StartCoroutine(WaitAndDeactivate(_enemyData.DeathDuration));
    }

    private IEnumerator WaitAndDeactivate(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _enemyHealth.OnEnemyDeath -= EnemyDie;
    }
}
