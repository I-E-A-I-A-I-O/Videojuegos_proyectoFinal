using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC_Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> npcs = new List<GameObject>();
    [SerializeField] private Transform startLimit, endLimit;
    private void Start()
    {
        RandomSpawn();
    }

    public void RandomSpawn()
    {
        var npcInScene = Random.Range(10, 61);
        for (var i = 0; i < npcInScene; i++)
        {
            var npc = Instantiate(npcs[Random.Range(0, npcs.Count)], 
                new Vector3(Random.Range(-4.79f, -14.5f), 0.099f, 
                    Random.Range(startLimit.transform.position.z, endLimit.transform.position.z)),
                Quaternion.Euler(0, Random.Range(-360f, 360f), 0));
        } 
    }
}
