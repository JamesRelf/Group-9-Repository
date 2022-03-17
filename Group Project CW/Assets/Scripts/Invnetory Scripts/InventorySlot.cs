using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] Button removeItemButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        itemImage.sprite = item.icon;
        itemImage.enabled = true;
        removeItemButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        itemImage.sprite = null;
        itemImage.enabled = false;
        removeItemButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.inventoryInstance.RemoveItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
