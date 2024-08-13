using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Transform _bird;
    [SerializeField] private float _offset;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.position.x + _offset;
        transform.position = position;
    }
}
