using UnityEngine;


public class BirdAttacker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private float _directionX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = _spawner.Get();
            bullet.Init(_bird.transform.rotation, _directionX);
        }
    }


}
