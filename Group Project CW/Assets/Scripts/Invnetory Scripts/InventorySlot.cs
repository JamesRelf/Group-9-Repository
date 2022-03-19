// Code edited from Brackeys (2017) INVENTORY CODE - Making an RPG in Unity (E06). How to make an RPG in Unity. 
//[Online Video] Available at: https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7 [Accessed 11/02/2022]
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
