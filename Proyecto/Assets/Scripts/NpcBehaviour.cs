using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcBehaviour : MonoBehaviour
{
    private bool _state;
    private Animator _npcAnim;

    private static readonly int Run = Animator.StringToHash("Run"),
        Scared = Animator.StringToHash("Scared");
    private void Start()
    {
        GameObject.FindWithTag("Main").GetComponent<Main>().npcInScene.Add(gameObject);
        _npcAnim = gameObject.GetComponent<Animator>();
    }

    public void RunAway(int probability)
    {
        RandState(2);
        gameObject.transform.LookAt(_state ? new Vector3(-9999, -2.384186e-07f, -6) : new Vector3(9999, -2.384186e-07f, -6));
        _npcAnim.SetTrigger(_state ? Run : Scared);
    }
    
    private void RandState(int probability)
    {
        _state = Random.Range(0, 9) > probability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) RunAway(7);
    }
}