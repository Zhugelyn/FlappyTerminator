using System;
using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler)),
 RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdCollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;
    public event Action ResetGame;

    private void Awake()
    {
        _collisionHandler = GetComponent<BirdCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
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

    public void Reset()
    {
        _scoreCounter.Reset();
        ResetGame?.Invoke();
    }
}
