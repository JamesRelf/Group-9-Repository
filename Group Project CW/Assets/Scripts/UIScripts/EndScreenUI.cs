using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;
    EndScreenSlot[] endScreenSlots;

    void Start()
    {
        inventory = Inventory.inventoryInstance;
        inventory.onItemChanged += UpdateEndScreenUI;

        endScreenSlots = itemsParent.GetComponentsInChildren<EndScreenSlot>();
    }

    void UpdateEndScreenUI()
    {
        for (int i = 0; i < endScreenSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                endScreenSlots[i].AddItem(inventory.items[i]);
            }
        }
    }
}
