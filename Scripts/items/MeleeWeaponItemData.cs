using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Melee Weapon Item Data", menuName = "Item/Melee Weapon Item Data")]
public class MeleeWeaponItemData : ItemData
{
    [Header("Melee Weapon Item Data")]
    public int Damage;
    public float Range;
    public float AttackRate;
}
