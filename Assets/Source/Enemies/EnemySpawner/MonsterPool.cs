using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MonsterPool : MonoBehaviour
{
    [SerializeField] private GameObject _poolParent;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private int _spawnCountPerPrefab = 3;

    private List<GameObject> pool = new List<GameObject>();

    [Inject] private PlayerData _playerData;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        foreach (GameObject prefab in _enemyPrefabs)
        {
            for (int i = 0; i < _spawnCountPerPrefab; i++)
            {
                GameObject obj = Instantiate(prefab, _poolParent.transform);
                InitializeEnemy(obj);

                obj.SetActive(false);

                pool.Add(obj);
            }
        }
    }

    public GameObject GetObjectFromPool()
    {
        List<int> inactiveIndices = new List<int>();
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                inactiveIndices.Add(i);
            }
        }

        if (inactiveIndices.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveIndices.Count);
            int selectedIndex = inactiveIndices[randomIndex];

            pool[selectedIndex].SetActive(true);
            return pool[selectedIndex];
        }
        else
        {
            GameObject newObj = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)], _poolParent.transform);

            InitializeEnemy(newObj);
            pool.Add(newObj);

            return newObj;
        }
    }

    private void InitializeEnemy(GameObject enemy)
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        EnemyAttackBehaviour enemyAttack = enemy.GetComponent<EnemyAttackBehaviour>();

        if (enemyHealth)
        {
            enemyHealth.OnEnemyDeath += MonsterKillCounter.UpdateDestroyedMonsterCount;
        }

        if (enemyAttack)
        {
            enemyAttack.Initialize(_playerData);
        }
    }
}
