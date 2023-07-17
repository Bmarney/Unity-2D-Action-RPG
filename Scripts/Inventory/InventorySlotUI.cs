using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private ItemSlot itemSlot;

    public void SetItemSlot(ItemSlot slot)
    {
        itemSlot = slot;
        if (slot.Item == null)
        {
            icon.enabled = false;
            quantityText.text = string.Empty;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.Item.Icon;
            quantityText.text = slot.Quantity > 1 ? slot.Quantity.ToString() : string.Empty; 
            // Ternary operator, basically a condensed if else statement based on what happens before the '?'
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (itemSlot.Item != null)
        {
            Inventory.Instance.UseItem(itemSlot);
        }
    }
}
