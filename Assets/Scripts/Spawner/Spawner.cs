using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T: MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private int _poolMaxSize;

    protected ObjectPool<T> Pool;

    private void Awake()
    {
        Pool = new ObjectPool<T>(
        createFunc: OnCreate,
        actionOnGet: (obj) => OnGet(obj),
        actionOnRelease: (obj) => OnRelease(obj),
        maxSize: _poolMaxSize);
    }

    protected virtual T OnCreate()
    {
        return Instantiate(_prefab);
    }

    protected virtual void OnGet(T obj)
    {
        obj.transform.position = _spawnPosition.position;
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
