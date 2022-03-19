// Code edited from Brackeys (2017) INVENTORY CODE - Making an RPG in Unity (E06). How to make an RPG in Unity. 
//[Online Video] Available at: https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7 [Accessed 11/02/2022]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject shoppingListUI;

    Inventory inventory;
    InventorySlot[] itemSlots;


    void Start()
    {
        inventory = Inventory.inventoryInstance;
        inventory.onItemChanged += UpdateUI;

        itemSlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            if (inventoryUI.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (inventoryUI.activeSelf == true)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            shoppingListUI.SetActive(!shoppingListUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                itemSlots[i].ClearSlot();
            }
        }
    }
}
