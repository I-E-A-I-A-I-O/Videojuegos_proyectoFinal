using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponParent;
    [SerializeField] private GameObject pistol, rifle;
    private GameObject _playerWeapon;
    private void Start()
    {
        EquipPistol();
    }

    public void EquipPistol()
    {
        if (!(_playerWeapon == null)) Destroy(_playerWeapon);
        _playerWeapon = Instantiate(pistol, weaponParent);
        _playerWeapon.GetComponent<WeaponScript>().isEquipped = true;
        _playerWeapon.transform.localPosition = new Vector3(-0.003986085f, 0.003670245f, -0.003213505f);
        gameObject.GetComponent<Movement>().weapon = 0;
        gameObject.GetComponent<Movement>().ChangeWeapon();
    }
    public void EquipRifle()
    {
        if (!(_playerWeapon == null)) Destroy(_playerWeapon);
        _playerWeapon = Instantiate(rifle, weaponParent);
        _playerWeapon.GetComponent<WeaponScript>().isEquipped = true;
        _playerWeapon.transform.localPosition = new Vector3(0.007219082f, 0.001656678f, 9.831507e-05f);
        gameObject.GetComponent<Movement>().weapon = 1;
        gameObject.GetComponent<Movement>().ChangeWeapon();
    }
}
