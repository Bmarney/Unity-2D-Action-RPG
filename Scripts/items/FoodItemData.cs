using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Food Item Data", menuName = "Item/Food Item Data")]
public class FoodItemData : ItemData
{
    [Header("Food Item Data")]
    public int HealthToGive;
}
