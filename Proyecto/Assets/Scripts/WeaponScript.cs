using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool isEquipped;
    public int clipSize;
    private int _remainingBullets;
    private bool _shootDelay = true;
    private AudioSource[] _weaponSounds;
    private ParticleSystem _shootingEffect;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject ammo;
    private void Start()
    {
        _weaponSounds = gameObject.GetComponents<AudioSource>();
        _shootingEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        _remainingBullets = clipSize;
    }

    private void Update()
    {
        if (!isEquipped) return;
        if (gameObject.name.Contains("Pistol"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_remainingBullets > 0)
                {
                    if (_shootDelay)
                    {
                        Shoot();
                        _weaponSounds[0].Play();
                        _shootDelay = false;
                        Invoke(nameof(Delay), 0.6f);
                    }
                }
                else
                {
                    _weaponSounds[1].Play();
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (_remainingBullets > 0)
                {
                    if (!_weaponSounds[0].isPlaying) _weaponSounds[0].Play();
                    if (_shootDelay)
                    {
                        Shoot();
                        if (!_weaponSounds[0].isPlaying) _weaponSounds[0].Play();
                        _shootDelay = false;
                        Invoke(nameof(Delay), 0.1f);
                    }
                }
                else
                {
                    if (_weaponSounds[0].isPlaying) _weaponSounds[0].Stop();
                    if (!_weaponSounds[2].isPlaying) _weaponSounds[2].Play();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (_remainingBullets > 0)
                {
                    _weaponSounds[0].Stop();
                    _weaponSounds[1].Play();
                }
                else
                {
                    if (_weaponSounds[2].isPlaying) _weaponSounds[2].Stop();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var index = gameObject.name.Contains("Pistol") ? 2 : 3;
            _weaponSounds[index].Play();
            Invoke(nameof(Reload), 2);
        }
    }

    private void Shoot()
    {
        Instantiate(ammo, shootPoint.position, Quaternion.Euler(0, 0, 0));
        _remainingBullets--;
        _shootingEffect.Play();
        GameObject.FindWithTag("Main").GetComponent<Main>().ShootSignal();
    }

    private void Reload()
    {
        _remainingBullets = clipSize;
    }

    private void Delay()
    {
        _shootDelay = true;
    }
}
