using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory inventoryInstance;

    void Awake()
    {
        CreateInventoryInstance();
    }

    void CreateInventoryInstance()
    {
        if (inventoryInstance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        inventoryInstance = this;
    }
    #endregion

    //Call to communicate inventory has changed
    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    public int inventorySpace = 4;

    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (items.Count >= inventorySpace)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items.Add(item);

        if (onItemChanged != null)
        {
            onItemChanged.Invoke();
        }

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChanged != null)
        {
            onItemChanged.Invoke();
        }
    }
}
