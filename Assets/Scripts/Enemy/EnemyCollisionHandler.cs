using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    public event Action<Enemy> Detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = GetComponent<Enemy>();
        Detected?.Invoke(enemy);
    }
}
