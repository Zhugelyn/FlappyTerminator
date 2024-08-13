using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] protected float DirectionX;
    [SerializeField] private float _lifetime;

    private Coroutine _coroutine;

    protected Bullet Get()
    {
        var bullet = Pool.Get();
        bullet.Force(DirectionX);

        _coroutine = StartCoroutine(CountDownLife(bullet));

        return bullet;
    }

    private IEnumerator CountDownLife(Bullet bullet)
    {
        float delay = 1f;
        var wait = new WaitForSeconds(delay);

        for (int i = 0; i < _lifetime; i++)
            yield return wait;

        ReturnToPool(bullet);

        if (_coroutine != null)
            StopCoroutine(CountDownLife(bullet));
    }

    private void ReturnToPool(Bullet bullet)
    {
        Pool.Release(bullet);
    }
}
