using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    [SerializeField] private GameObject bloodSprite;
    private ParticleSystem _bloodDrops, _bloodSmoke;
    private List<ParticleSystem.Particle> _enter = new List<ParticleSystem.Particle>();

    private void Start()
    {
        _bloodDrops = GetComponent<ParticleSystem>();
        _bloodSmoke = gameObject.transform.root.GetComponentsInChildren<ParticleSystem>()[1];
    }

    private void OnParticleTrigger()
    {
        var enterParticles = _bloodDrops.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _enter);
        for (var i = 0; i < enterParticles; i++)
        {
            var particle = _enter[i];
            var sprite = Instantiate(bloodSprite, new Vector3(particle.position.x, 0.12f, particle.position.z),
                Quaternion.Euler(90, 0, 0));
            Destroy(sprite, 3);
        }
    }

    public void Bleed(Vector3 hitPoint)
    {
        WoundPosition(hitPoint);
        SetColliders();
        _bloodDrops.Play();
        _bloodSmoke.Play();
    }

    private void WoundPosition(Vector3 hitPoint)
    {
        _bloodDrops.transform.position = hitPoint;
        _bloodDrops.transform.LookAt(new Vector3(0, 0.5f, 40));
        _bloodSmoke.transform.position = hitPoint;
    }

    private void SetColliders()
    {
        var triggerModule = _bloodDrops.trigger;
        var bloodColliders = GameObject.FindGameObjectsWithTag("Object");
        for (var i = 0; i < bloodColliders.Length; i++)
        {
            triggerModule.SetCollider(i, bloodColliders[i].GetComponent<Collider>());
        }
    }
}
