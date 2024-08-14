using System;
using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler)),
 RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.Detected += DeclareEnd;
    }

    private void OnDisable()
    {
        _collisionHandler.Detected -= DeclareEnd;
    }

    private void DeclareEnd(IInterectable interectable)
    {
        GameOver?.Invoke();
    }
}
