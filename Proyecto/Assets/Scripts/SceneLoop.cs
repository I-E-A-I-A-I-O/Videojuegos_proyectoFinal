using UnityEngine;

public class SceneLoop : MonoBehaviour
{
    [SerializeField] private GameObject hall, hallLimits;
    private GameObject _newHall, _oldHall;

    private void Start()
    {
        _newHall = GameObject.FindWithTag("World");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _oldHall = _newHall;
            var oldHallPos = _oldHall.transform.position;
            _newHall = Instantiate(hall, new Vector3(oldHallPos.x, oldHallPos.y, oldHallPos.z - 254),
                Quaternion.Euler(0, 0, 0));
            var hallLimitsPos = hallLimits.transform.position;
            hallLimits.transform.position = new Vector3(hallLimitsPos.x, hallLimitsPos.y, 
                hallLimitsPos.z - 252);
            GameObject.FindWithTag("Main").GetComponent<NPC_Spawn>().RandomSpawn();
        }
    }
}
