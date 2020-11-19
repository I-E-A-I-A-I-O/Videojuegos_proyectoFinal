using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Main : MonoBehaviour
{
    [FormerlySerializedAs("npcInScene")] public List<GameObject> behaviourList = new List<GameObject>();
    public GameObject player;
    public int rifleBonusCount = 49;
    private AudioSource[] _gameSongs;
    private bool _isBonusActive;
    public GameObject[] lights;
    private static readonly int LightsTrigger = Animator.StringToHash("KillTrigger");
    private void Start()
    {
        _gameSongs = gameObject.GetComponents<AudioSource>();
        lights = GameObject.FindGameObjectsWithTag("HallLights");
    }

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
    private IEnumerator RifleBonusCount()
    {
        if (rifleBonusCount > 0) rifleBonusCount--;
        else
        {
            player.GetComponent<EquippedWeapon>().EquipRifle();
            _gameSongs[1].Play();
            _isBonusActive = true;
            yield return new WaitForSeconds(22);
            player.GetComponent<EquippedWeapon>().EquipPistol();
            _isBonusActive = false;
            rifleBonusCount = 49;
        }
    }

    private void KillLights()
    {
        foreach (var light in lights)
        {
            if (light == null) continue;
            light.GetComponent<Animator>().SetTrigger(LightsTrigger);
        }
    }
    public void DeathCount()
    {
        KillLights();
        if (_isBonusActive) return;
        StartCoroutine(RifleBonusCount());
    }
}
