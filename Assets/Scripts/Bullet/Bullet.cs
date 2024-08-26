using UnityEngine;

public class Bullet : MonoBehaviour, IInterectable
{
    [SerializeField] private float _speed;

    private float _directionX;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * _directionX * Time.deltaTime);
    }

    public void Init(Quaternion quaternion, float directionX)
    {
        transform.rotation = quaternion;
        _directionX = directionX;
    }
}
