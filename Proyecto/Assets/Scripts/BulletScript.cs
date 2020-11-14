using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.Rotate(gameObject.name.Contains("Pistol") ? -90 : -180, 0, 0, Space.World);
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag("NPC"))
        {
            other.transform.root.GetComponent<RagdollScript>().Die();
        }
    }
}
