using UnityEngine;
using Random = UnityEngine.Random;

public class NpcBehaviour : MonoBehaviour
{
    private bool _state, _runningAway, _dead;
    private Animator _npcAnim;

    private static readonly int Run = Animator.StringToHash("Run"),
        Scared = Animator.StringToHash("Scared");
    private void Start()
    {
        GameObject.FindWithTag("Main").GetComponent<Main>().behaviourList.Add(gameObject);
        _npcAnim = gameObject.GetComponent<Animator>();
    }

    public void RunAway(int probability)
    {
        if (_runningAway || _dead) return;
        RandState(probability);
        gameObject.transform.LookAt(_state ? new Vector3(9999, -2.384186e-07f, -6) : new Vector3(-9999, -2.384186e-07f, -6));
        _npcAnim.SetTrigger(_state ? Run : Scared);
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
        Destroy(gameObject, 3);
    }
}