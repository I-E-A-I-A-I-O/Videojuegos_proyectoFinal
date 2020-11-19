using UnityEngine;
using Random = UnityEngine.Random;

public class NpcBehaviour : MonoBehaviour
{
    private bool _state, _runningAway, _dead;
    private Animator _npcAnim;
    private AudioSource[] _npcSounds;

    private static readonly int Run = Animator.StringToHash("Run"),
        Scared = Animator.StringToHash("Scared");
    private void Start()
    {
        GameObject.FindWithTag("Main").GetComponent<Main>().behaviourList.Add(gameObject);
        _npcAnim = gameObject.GetComponent<Animator>();
        _npcSounds = GetComponents<AudioSource>();
        _npcSounds[2].Play();
    }

    public void RunAway(int probability)
    {
        if (_runningAway || _dead) return;
        RandState(probability);
        gameObject.transform.LookAt(_state ? new Vector3(9999, -2.384186e-07f, -6) : new Vector3(-9999, -2.384186e-07f, -6));
        _npcAnim.SetTrigger(_state ? Run : Scared);
        StopSounds();
        _npcSounds[_state ? 0 : 1].Play();
    }
    
    private void RandState(int probability)
    {
        _state = Random.Range(0, 9) > probability;
        if (_state) _runningAway = _state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) RunAway(7);
    }

    public void SetDead()
    {
        _dead = true;
        StopSounds();
        GameObject.FindWithTag("Main").GetComponent<Main>().DeathCount();
        Destroy(gameObject, 3);
    }

    private void StopSounds()
    {
        foreach(var asrc in _npcSounds)
        {
            if (asrc.isPlaying) asrc.Stop();
        }
    }
}