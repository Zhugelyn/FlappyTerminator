using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : BulletSpawner
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(SpawnBullet());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(SpawnBullet());
    }

    private IEnumerator SpawnBullet()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Get();

            yield return wait;
        }
    }
}
