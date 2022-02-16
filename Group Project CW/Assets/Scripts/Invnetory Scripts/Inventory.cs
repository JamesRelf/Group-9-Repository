using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    //Call to communicate inventory has changed
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallback;

    public int inventorySpace = 20;

    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (items.Count >= inventorySpace)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items.Add(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }

        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
}
