using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private float _minSpawnTime = 2;
    [SerializeField] private float _maxSpawnTime = 5;

    [SerializeField] private Transform _leftSideSpawnPoint;
    [SerializeField] private Transform _rightSideSpawnPoint;

    [SerializeField] private MonsterPool _monsterPool;

    private void Start()
    {
        StartCoroutine(SpawnMonstersRoutine());
    }

    private IEnumerator SpawnMonstersRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));

            Transform spawnPoint = Random.Range(0, 2) == 0 ? _leftSideSpawnPoint : _rightSideSpawnPoint;

            GameObject monster = _monsterPool.GetObjectFromPool();
            if (monster)
            {
                monster.transform.position = spawnPoint.position;
                monster.SetActive(true);

                SpriteRenderer spriteRenderer = monster.GetComponent<SpriteRenderer>();

                if (spriteRenderer)
                {
                    if (spawnPoint == _rightSideSpawnPoint)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }
            }
        }
    }
}
