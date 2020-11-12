using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back);
    }
}
