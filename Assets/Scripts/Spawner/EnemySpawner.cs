using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private BoxCollider2D _movementArea;
    [SerializeField] private Game _game;

    private Coroutine _coroutine;

    public event Action Pooling;

    private void OnEnable()
    {
        _game.GameStarted += StartSpawn;
    }

    private void OnDisable()
    {
        _game.GameStarted -= StartSpawn;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
             
            var enemy = Pool.Get();
            enemy.Init(_movementArea);

            if (enemy.TryGetComponent(out EnemyCollisionHandler enemyCollisionHandler))
                enemyCollisionHandler.Detected += ReturnToPool;
        }
    }

    private void ReturnToPool(Enemy enemy)
    {
        Pooling?.Invoke();
        Pool.Release(enemy);

        enemy.GetComponent<EnemyCollisionHandler>().Detected -= ReturnToPool;
    }

    private void StartSpawn()
    {
        _coroutine = StartCoroutine(Spawn());
    }
}

