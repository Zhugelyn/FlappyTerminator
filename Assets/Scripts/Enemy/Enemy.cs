using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour, IInterectable
{
    public void Init(BoxCollider2D movementArea)
    {
        var enemyMover = GetComponent<EnemyMover>();
        enemyMover.Init(movementArea);
    }
}
