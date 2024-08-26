using System.Collections;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private float _lifetime;

    private Coroutine _coroutine;

    public virtual Bullet Get()
    {
        var bullet = Pool.Get();

        StartCoroutine(bullet);

        return bullet;
    }

    protected void StartCoroutine(Bullet bullet)
    {
        _coroutine = StartCoroutine(CountDownLife(bullet));
    }

    protected IEnumerator CountDownLife(Bullet bullet)
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
