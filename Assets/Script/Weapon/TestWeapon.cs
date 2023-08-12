using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    public WeaponController weaponController;
    public List<Weapon> Wepons = new List<Weapon>();
    public Weapon activeWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = Wepons[0].GetComponent<Weapon>();
            RefreshWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeapon = Wepons[1].GetComponent<Weapon>();
            RefreshWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeWeapon = Wepons[2].GetComponent<Weapon>();
            RefreshWeapon();
        }

    }

    private void RefreshWeapon()
    {
        foreach (var weapon in Wepons)
        {
            if (weapon != activeWeapon) weapon.gameObject.SetActive(false);
            else weapon.gameObject.SetActive(true);
        }

        weaponController._currentWeapon = activeWeapon;
    }
}
