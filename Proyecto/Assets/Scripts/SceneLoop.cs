using UnityEngine;

public class SceneLoop : MonoBehaviour
{
    [SerializeField] private GameObject startPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = startPos.transform.position;
        }
    }
}
