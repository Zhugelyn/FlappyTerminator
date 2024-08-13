using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action<IInterectable> Detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInterectable interectable))
            Detected?.Invoke(interectable);
    }
}
