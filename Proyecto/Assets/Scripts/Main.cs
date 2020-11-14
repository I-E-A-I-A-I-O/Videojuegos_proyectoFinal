using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public List<GameObject> npcInScene = new List<GameObject>();
    public GameObject player;

    public void ShootSignal()
    {
        foreach (var npc in npcInScene)
        {
            if (Vector3.Distance(player.transform.position, npc.transform.position) < 10)
            {
                npc.GetComponent<NpcBehaviour>().RunAway(2);
            }
        }
    }
}
