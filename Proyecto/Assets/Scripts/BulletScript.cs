using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.Rotate(gameObject.name.Contains("Pistol") ? -90 : -180, 0, 0, Space.World);
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag("NPC"))
        {
            var root = other.transform.root;
            root.GetComponent<RagdollScript>().Die();
            root.GetComponentInChildren<BloodScript>().Bleed(gameObject.transform.position);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("NPC"))
        {
            var root = other.transform.root;
            root.GetComponent<NpcBehaviour>().RunAway(2);
        }
    }
}
