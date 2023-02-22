using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(2);
        }

    }

    private void SetWeapon(int weaponNumber)
    {
       for(int i = 0; i < weapons.Length; i++)
        {
            var currentWeapon = weapons[i];

            if (i == weaponNumber)
            {
                currentWeapon.SetActive(true);
            }
            else
            {
                currentWeapon.SetActive(false);
            }
        }
    }
}