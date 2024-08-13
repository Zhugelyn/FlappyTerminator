using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private BoxCollider2D _movementArea;
    [SerializeField] private Bird _bird;

    private Coroutine _coroutine;

    public event Action Pooling;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Spawn());
        _bird.ResetGame += ClearPool;
    }

    private void OnDisable()
    {
        _bird.ResetGame -= ClearPool;
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            var enemy = Pool.Get();
            enemy.Init(_movementArea);

            if (enemy.TryGetComponent(out EnemyCollisionHandler enemyCollisionHandler))
                enemyCollisionHandler.Detected += ReturnToPool;

            yield return wait;
        }
    }

    private void ReturnToPool(Enemy enemy)
    {
        Pooling?.Invoke();
        Pool.Release(enemy);

        enemy.GetComponent<EnemyCollisionHandler>().Detected -= ReturnToPool;
    }

    private void ClearPool()
    {
        Debug.Log(" Dispose");
        Pool.Clear();
    }
}

