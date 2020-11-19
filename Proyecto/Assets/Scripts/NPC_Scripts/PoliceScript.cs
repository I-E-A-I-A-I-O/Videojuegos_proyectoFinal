using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoliceScript : MonoBehaviour
{
    private GameObject gun;
    private void Start()
    {
        gun = transform.Find("Pistol").gameObject;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (!GameObject.FindWithTag("Player").GetComponent<Movement>().dead)
        {
            if (ShootProbability()) ShootWeapon();
            yield return new WaitForSeconds(5);
        }
    }

    private bool ShootProbability()
    {
        var random = Random.Range(1, 11);
        return random < 5;
    }

    private void ShootWeapon()
    {
        if (gun.GetComponent<WeaponScript>().remainingBullets == 0 ) gun.GetComponent<WeaponScript>().Reload();
        gun.GetComponent<WeaponScript>().Shoot();
    }
}
