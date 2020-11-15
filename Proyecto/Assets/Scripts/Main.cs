using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Main : MonoBehaviour
{
    [FormerlySerializedAs("npcInScene")] public List<GameObject> behaviourList = new List<GameObject>();
    public GameObject player;

    public void ShootSignal()
    {
        foreach (var npc in behaviourList)
        {
            if (npc == null) continue;
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 10)
            {
                npc.GetComponent<NpcBehaviour>().RunAway(2);
            }
        }
    }
}
