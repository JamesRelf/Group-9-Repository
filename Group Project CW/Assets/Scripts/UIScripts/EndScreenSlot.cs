using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndScreenSlot : MonoBehaviour
{
    public Image itemImage;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        itemImage.sprite = item.icon;
        itemImage.enabled = true;
    }
}
