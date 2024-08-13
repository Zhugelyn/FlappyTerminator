using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private BoxCollider2D _movementArea;
    private Vector3 _newPosition;

    public void Init(BoxCollider2D movementArea)
    {
        _movementArea = movementArea;
        _newPosition = SetNewPostion();
    }

    private void Update()
    {
        if (_newPosition == null || _newPosition == transform.position)
            _newPosition = SetNewPostion();

        transform.position = Vector3.MoveTowards(transform.position, _newPosition, _speed * Time.deltaTime);
    }

    private Vector3 SetNewPostion()
    {
        var positionArea = _movementArea.transform.position;

        var maxPosX = positionArea.x + _movementArea.size.x / 2;
        var minPosX = positionArea.x - _movementArea.size.x / 2;
        var maxPosY = positionArea.y + _movementArea.size.y / 2;
        var minPosY = positionArea.y - _movementArea.size.y / 2;

        var posX = Random.Range(minPosX, maxPosX);
        var posY = Random.Range(minPosY, maxPosY);

        return new Vector3(posX, posY, 0);
    }
}
