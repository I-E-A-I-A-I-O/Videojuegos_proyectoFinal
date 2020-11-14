using UnityEngine;

public class SceneLoop : MonoBehaviour
{
    [SerializeField] private GameObject startPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, startPos.transform.position.z);
        }
    }
}
