using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += StopGame;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= StopGame;
    }

    private void StopGame(IInterectable interectable)
    {
        Time.timeScale = 0;
    }
}
