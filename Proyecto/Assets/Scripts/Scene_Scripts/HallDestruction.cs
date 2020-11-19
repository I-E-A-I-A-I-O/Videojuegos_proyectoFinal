using UnityEngine;

public class HallDestruction : MonoBehaviour
{
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(transform.root.gameObject, 5);
        }
    }
}
