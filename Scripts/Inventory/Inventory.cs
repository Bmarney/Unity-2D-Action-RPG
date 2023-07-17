using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] starterItems; // The specified starter items array
    [SerializeField] private int inventorySize; // Max number of slots for inventory
    private ItemSlot[] itemSlots; // The slots for the players inventory

    public InventoryUI UI; // A reference to the UI for the inventory

    public static Inventory Instance; // This instance of inventory

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        itemSlots = new ItemSlot[inventorySize];
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = new ItemSlot();
        }

        // Add the starter items
        for (int i = 0; i< starterItems.Length; i++)
        {
            AddItem(starterItems[i]);
        }
    }

    // Adds an item to the inventory
    public void AddItem(ItemData item)
    {
        ItemSlot slot = FindAvailableItemSlot(item);
        
        if (slot != null)
        {
            slot.Quantity++;
            UI.UpdateUI(itemSlots);
            return;
        }

        slot = GetEmptySlot();
        
        if (slot != null)
        {
            slot.Item = item;
            slot.Quantity = 1;
        }
        else
        {
            Debug.Log("Inventory is full!");
            return;
        }

        UI.UpdateUI(itemSlots);

    }

    // Removes the requested item from the inventory
    public void RemoveItem(ItemData item)
    {
        for (int i = 0; i< itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                RemoveItem(itemSlots[i]);
                return;
            }
        }
    }

    // Removes an item from the requested slot
    public void RemoveItem(ItemSlot slot)
    {
        if (slot == null)
        {
            Debug.LogError("Can't remove item from inventory!");
            return;
        }

        slot.Quantity--;
        if (slot.Quantity <= 0)
        {
            slot.Item = null;
            slot.Quantity = 0;
        }

        UI.UpdateUI(itemSlots);
    }

    // Loops through looking for an available slot that already has the item in it
    // Double checks the MaxStackSize for that item wont be exceeded
    ItemSlot FindAvailableItemSlot(ItemData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item && itemSlots[i].Quantity < item.MaxStackSize)
                return itemSlots[i];
        }
        return null;
    }

    // Loops through looking for an available slot and returns one if found
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
                return itemSlots[i];
        }

        return null;

    }

    // Called when we click on an item slot
    public void UseItem(ItemSlot slot)
    {
        if (slot.Item is MeleeWeaponItemData || slot.Item is RangedWeaponItemData)
        {
            Player.Instance.EquipCtrl.Equip(slot.Item);
        }
        else if (slot.Item is FoodItemData)
        {
            FoodItemData food = slot.Item as FoodItemData;
            Player.Instance.Heal(food.HealthToGive);

            RemoveItem(slot);
        }
        
    }

    // Do we have the requested item?
    public bool HasItem(ItemData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item && itemSlots[i].Quantity > 0)
                return true;
        }
        
        return false;
    }
}
