using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private int _count;

    public event Action<int> Changed;

    public int Count => _count;

    private void OnEnable()
    {
        _enemySpawner.Pooling += AddPoints;
    }

    private void OnDisable()
    {
        _enemySpawner.Pooling -= AddPoints;
    }

    private void AddPoints()
    {
        _count++;

        Changed?.Invoke(_count);
    }
}
