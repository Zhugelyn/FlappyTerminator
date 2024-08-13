using UnityEngine;

public class BirdBulletSpawner : BulletSpawner
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Get();
    }                
}
