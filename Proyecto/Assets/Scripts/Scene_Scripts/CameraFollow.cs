using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform _gameObjectTransform;
    private void Start()
    {
        _gameObjectTransform = gameObject.transform;
    }

    private void LateUpdate()
    {
        var targetPosition = target.transform.position;
        var gameObjectPos = gameObject.transform.position;
        _gameObjectTransform.position = new Vector3(gameObjectPos.x, gameObjectPos.y,
            targetPosition.z + 8);
    }
}
