using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyPrefab _enemyPrefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemyPrefab, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
