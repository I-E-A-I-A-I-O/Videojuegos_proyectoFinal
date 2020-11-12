using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool isEquipped;
    private AudioSource[] _weaponSounds;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject ammo;
    private void Start()
    {
        _weaponSounds = gameObject.GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (gameObject.name.Contains("Pistol"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
                _weaponSounds[0].Play();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (!_weaponSounds[0].isPlaying) _weaponSounds[0].Play();
                if (IsInvoking(nameof(Shoot))) return;
                Invoke(nameof(Shoot), .2f);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _weaponSounds[0].Stop();
                _weaponSounds[1].Play();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(ammo, shootPoint.position, Quaternion.Euler(0, 0, 0));
    }
}
