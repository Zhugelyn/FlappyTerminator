using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private int _count;

    public event Action<int> Changed;

    public int Count => _count;

    private void OnEnable()
    {
        _spawner.Pooling += AddPoints;
    }

    private void OnDisable()
    {
        _spawner.Pooling -= AddPoints;
    }

    private void AddPoints()
    {
        _count++;

        Changed?.Invoke(_count);
    }

    public void Reset()
    {
        _count = 0;

        Changed?.Invoke(_count);
    }
}
