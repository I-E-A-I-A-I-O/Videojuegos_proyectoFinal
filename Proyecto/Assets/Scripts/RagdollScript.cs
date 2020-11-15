using UnityEngine;

public class RagdollScript : MonoBehaviour
{
    private void Start()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
    }

    public void Die()
    {
        GetComponent<NpcBehaviour>().SetDead();
        GetComponent<Animator>().enabled = false;
        SetRigidbodyState(false);
        SetColliderState(true);
        if (GameObject.FindWithTag("Main").GetComponent<Main>().behaviourList.Contains(gameObject))
        {
            GameObject.FindWithTag("Main").GetComponent<Main>().behaviourList.Remove(gameObject);
        }
    }
    private void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    private void SetColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (var cr in colliders)
        {
            cr.enabled = state;
        }

        var myColls = GetComponents<Collider>();
        foreach (var coll in myColls)
        {
            coll.enabled = !state;
        }
    }
}
