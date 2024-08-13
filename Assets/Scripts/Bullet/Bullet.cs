using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInterectable
{
    [SerializeField] private float _force;

    public void Init()
    {
    }

    public void Force(float directionX)
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(directionX, 0) * _force;
    }
}
