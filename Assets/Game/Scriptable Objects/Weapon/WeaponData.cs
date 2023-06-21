using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public List<GameObject> listWeapon;
    public GameObject GetWeapon(int weaponId)
    {
        return listWeapon[(int)weaponId];
    }
}
