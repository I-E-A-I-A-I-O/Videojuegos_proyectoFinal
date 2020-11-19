using UnityEngine;

public class PoliceDistanceTrigger : MonoBehaviour
{
    private float _enterTime;
    private bool _loop;

    private void Update()
    {
        if (_loop)
        {
            if (Time.realtimeSinceStartup - _enterTime > 5)
            {
                gameObject.GetComponent<Movement>().Die();
                _loop = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Police"))
        {
            _enterTime = Time.realtimeSinceStartup;
            _loop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Police"))
        {
            _loop = false;
        }
    }
}
