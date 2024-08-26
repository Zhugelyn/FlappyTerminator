using System.Collections;
using UnityEngine;

public class EnemyAttacker : BulletSpawner
{
    [SerializeField] private float _delay;
    [SerializeField] private float _directionX;

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
            var bullet = Get();
            bullet.Init(Quaternion.identity, _directionX);

            yield return wait;
        }
    }
}
