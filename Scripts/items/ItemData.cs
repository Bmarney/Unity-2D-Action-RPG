using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item/Genaric Item")]
public class ItemData : ScriptableObject
{
    public string DisplayName;
    public string Description;
    public Sprite Icon;

    public int MaxStackSize = 1;

    public GameObject EquipPrefab;
}
